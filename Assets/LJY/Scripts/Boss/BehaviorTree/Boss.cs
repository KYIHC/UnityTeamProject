using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Boss : Monster
{
    #region public
    public float attackRange = 5.5f;
    public Transform rayPosition;
    public int patterCount;
    #endregion
    #region private
    private BTSelector root;
    private BossAttack bossAttack;
    private NavMeshAgent nav;
    private Animator anim;
    private bool isDie = false;
    #endregion
 
    private void Start()
    {
        root = new BTSelector();
        bossAttack = GetComponent<BossAttack>();
        BTSequence lifeCheckSequence = new BTSequence();
        BTSequence attackSequence = new BTSequence();
        BTSequence chaseSequence = new BTSequence();
        BTAction dieAction = new BTAction(Die);
        BTAction attackActtion = new BTAction(Attack);
        BTAction chaseActtion = new BTAction(Chase);
        BTCondition playerRange = new BTCondition(IsPlayerInRange);
        BTCondition playerDie = new BTCondition(IsPlayerDie);
        
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        root.AddChild(lifeCheckSequence);
        root.AddChild(attackSequence);
        root.AddChild(chaseSequence);
        lifeCheckSequence.AddChild(playerDie);
        lifeCheckSequence.AddChild(dieAction);
        attackSequence.AddChild(playerRange);
        attackSequence.AddChild(attackActtion);
        chaseSequence.AddChild(chaseActtion);

        monsterName = MonsterDataManager.instance.bossPhaseOne.name; 
        maxHP = MonsterDataManager.instance.bossPhaseOne.maxHP;
        currentHP = maxHP;
        root.Evaluate();
        
    }

    private void Update()
    {
        root.Evaluate();
        if (currentHP <= 0)
        { currentHP = 0; }
    }

    private bool IsPlayerDie()
    {
        if (currentHP == 0) { return true;}
        else { return false; }
    }

    private bool IsPlayerInRange()
    {
        playerPosition = GameObject.FindWithTag("Player");
        float distanceToPlayer = Vector3.Distance(transform.position, playerPosition.transform.position);
        return distanceToPlayer <= attackRange;
    }
    public BTState Die()
    {
        if (isDie == false)
        {
            nav.isStopped = true;
            anim.SetTrigger("isStay");
            MUIManager.instance.BossUI.SetActive(false);
            Destroy(gameObject, 4.0f);
            DungeonManager.instance.phaseOneClear = true;
            ItemDatabase.instance.Money += 100;
            isDie = true;
            return BTState.Success;
        }
        else if (isDie == true)
        {
            return BTState.Success;
        }
        else { return BTState.Failure; }
    }
    public BTState Attack()
    {
        if (bossAttack.isAttack == false)
        {
            nav.isStopped = true;
            anim.SetBool("isChase", false);
            if (HeadCheck())
            {
                bossAttack.AttackPatterm(patterCount);
            }
            else
            {
                Quaternion targetRotation = Quaternion.LookRotation(playerPosition.transform.position - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5);
            }
            return BTState.Success;
        }
        else { return BTState.Success; }
    }

    public BTState Chase()
    {
        if (bossAttack.isAttack == false && !IsPlayerInRange())
        {
            Quaternion targetRotation = Quaternion.LookRotation(playerPosition.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5);
            nav.isStopped = false;
            anim.SetBool("isChase", true);
            nav.SetDestination(playerPosition.transform.position);
            return BTState.Success;
        }
        else { return BTState.Success; }
    }

    public override void Hit(float damage)
    {
        currentHP -= damage;
    }

    private void OnTriggerEnter(Collider other)
    {
      
        if (other.CompareTag("PlayerWeapon") && currentHP > 0)
        {
            Hit(other.GetComponent<PlayerWeapon>().damage);
            MUIManager.instance.BossUI.SetActive(true);
            MUIManager.instance.bossHpBar.fillAmount = currentHP / maxHP;
            MUIManager.instance.bossHpText.text = $"{currentHP + " / " + maxHP}";
            MUIManager.instance.bossName.text = $"{"�ذ��� ���� " + monsterName}";
            
        }
    }

    private bool HeadCheck()
    {
        RaycastHit hit;
        bool isHit = Physics.Raycast(rayPosition.position, rayPosition.forward, out hit, attackRange);
        if (isHit && hit.collider.CompareTag("Player"))
        {
            return true;
        }
        else { return false; }
    }

   
}

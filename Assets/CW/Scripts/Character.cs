using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using Newtonsoft.Json.Bson;

public class Character : MonoBehaviour, IHittable
{
    private Camera mainCamera;
    public GameObject[] weapons;



    public float stopDistance = 1.0f;

    public GameObject KickArea;
    public Animator anim;
    private Vector3 CharacterMove;

    private NavMeshAgent nav;

    public bool[] hasWeapon;
    public bool isMove;
    public bool isAttackReady;
    public bool isRolling;
    public bool attackCheck;
    public bool isRollingReady;
    public bool StopMode;
    public bool isDead = false;





    Weapon weapon;
    Vector3 RollingVec;



    float attackDelay;

    public float damage;
    

   



    private void Awake()
    {
        GameObject cameraObj = GameObject.FindWithTag("MainCamera");
        if (cameraObj != null)
        {
            mainCamera = cameraObj.GetComponent<Camera>();
        }
        isRollingReady = true;


        anim = GetComponentInChildren<Animator>();
        nav = GetComponent<NavMeshAgent>();
        nav.updateRotation = false;

        damage = PlayerDataManager.instance.playerData.attackDamage;




    }




    private void Update()
    {
        if (Input.GetMouseButton(1) && attackCheck == false)
        {

            RaycastHit hit;

            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                setCharacterMove(hit.point);


            }

        }

        Attack();
        Rolling();
        LookMoveDir();
        OnDie();
        damagepull();



        





    }
    public void Hit(float damage)
    {
        PlayerDataManager.instance.playerData.CurrentHp -= damage;
    }


    public void setCharacterMove(Vector3 charMove)
    {
        nav.isStopped = false;
        nav.SetDestination(charMove);
        CharacterMove = charMove;
        isMove = true;
        anim.SetBool("isMove", true);

    }

    public void LookMoveDir()
    {
        if (isMove == true)
        {
            if (nav.velocity.magnitude == 0f)
            {
                isMove = false;
                anim.SetBool("isMove", false);
                return;
            }
            var dir = new Vector3(nav.steeringTarget.x, transform.position.y, nav.steeringTarget.z) - transform.position;
            dir.y = 0;
            anim.transform.forward = dir;


        }


    }

    public void Attack()
    {
        anim.SetBool("Sword", false);
        int weaponIndex = 0;



        weapon = weapons[weaponIndex].GetComponent<Weapon>();
        weapon.gameObject.SetActive(true);




        attackDelay += Time.deltaTime;
        isAttackReady = weapon.attackSpeed < attackDelay;


        if (Input.GetMouseButton(0) && isAttackReady && !InventoryUI.instance.activeInventory)
        {
            attackCheck = true;
            weapon.useWeapon();
            switch (weapon.weaponType)
            {
                case Weapon.WeaponType.SWORD:

                    anim.SetBool("Sword", true);
                    break;
            }
            attackDelay = 0;


            StartCoroutine(resumeMove());

        }

    }

    void Rolling()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isRollingReady && nav.velocity.magnitude > 3f)
        {


            RollingVec = CharacterMove;
            nav.speed = 12;
            anim.SetTrigger("Rolling");
            isRolling = true;

            Invoke("RollingBreak", 0.5f);

            StartCoroutine(rollingInterval());
        }
    }

    void RollingBreak()
    {
        nav.speed *= 0.5f;
        isRolling = false;

    }




    public void ActivateSkill(SOSkill skill)
    {
        attackCheck = true;
        if (attackCheck == true)
        {
            anim.Play(skill.animationName);


        }
        if (skill.animationName == "Skill_Kick")
        {


            StartCoroutine(resumeMove());
        }
        if (skill.animationName == "Skill_Strike")
        {

            StartCoroutine(SkillStrike());
        }

    }

    IEnumerator rollingInterval()
    {

        isRollingReady = false;
        if (isRollingReady == false)
        {
            yield return new WaitForSeconds(5f);
            isRollingReady = true;
        }
        yield return null;
    }



    public void stopMove()
    {
        if (attackCheck == true)
            nav.isStopped = true;
        if (isMove == false)
            nav.isStopped = true;
    }

    public void OnDie()
    {
        if (PlayerDataManager.instance.playerData.CurrentHp <= 0 && !isDead)
        {
            isDead = true;
            nav.isStopped = true;
            Debug.Log("die");
            anim.SetTrigger("doDie");
        }
        return;
    }


    IEnumerator resumeMove()
    {
        PlayerDataManager.instance.playerData.attackDamage -= 10;
        KickArea.SetActive(true);
        nav.isStopped = true;
        yield return new WaitForSeconds(0.5f);
        attackCheck = false;
        PlayerDataManager.instance.playerData.attackDamage = PlayerDataManager.instance.playerDataList[0].attackDamage;;
        KickArea.SetActive(false);

        yield return null;
    }

    IEnumerator SkillStrike()
    {
        PlayerDataManager.instance.playerData.attackDamage *= 2;
        weapon.weaponArea.SetActive(true);
        nav.isStopped = true;

        yield return new WaitForSeconds(1.0f);
        attackCheck = false;

        weapon.weaponArea.SetActive(false);
        
        PlayerDataManager.instance.playerData.attackDamage = PlayerDataManager.instance.playerDataList[0].attackDamage;
        yield return null;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MonsterProjectile"))
        {
            MonsterProjectile projectile = other.GetComponent<MonsterProjectile>();
            Hit(projectile.damage);
        }
    }

    public void damagepull()
    {
        damage = PlayerDataManager.instance.playerData.attackDamage;
    }










}

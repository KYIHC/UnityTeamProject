using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BossAttack : MonoBehaviour
{
    #region
    public AnimationClip[] animationClip;
    #endregion

    #region public 변수
    public bool isAttack = false;
    public GameObject attackObject;
    public bool[] count;
    public float damage;
    #endregion

    #region private 변수
    private float groundSkillCoolTime;
    private float slashSkillCoolTime;
    private float jumpSkillCoolTime;
    private float spinSkillCoolTime;
    private float riseSkillCoolTime;
    private float currentDamage;
    private Animator anim;
    private NavMeshAgent nav;
    private BossParticle bossParticle;
    #endregion


    private void Start()
    {
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        bossParticle = GetComponent<BossParticle>();
        count = new bool[6];
        groundSkillCoolTime = MonsterDataManager.instance.bossPhaseTwo.skills[0].coolTime;
        slashSkillCoolTime = MonsterDataManager.instance.bossPhaseTwo.skills[1].coolTime;
        spinSkillCoolTime = MonsterDataManager.instance.bossPhaseTwo.skills[2].coolTime;
        riseSkillCoolTime = MonsterDataManager.instance.bossPhaseTwo.skills[3].coolTime;
        jumpSkillCoolTime = MonsterDataManager.instance.bossPhaseTwo.skills[4].coolTime;
        for (int i = 0; i < count.Length; i++)
        {
            count[i] = true;
        }
    }

    private void Update()
    {
        damage = currentDamage;
    }
    public void AttackPatterm(int patternCount)
    {

        while (isAttack == false)
        {
            int pattern = Random.Range(0, patternCount);

            if (count[pattern] == true && patternCount < 4)
            {
                switch (pattern)
                {
                    case 0:
                        StartCoroutine(NormalAttack());
                        break;
                    case 1:
                        StartCoroutine(GroundAttack());
                        break;
                    case 2:
                        StartCoroutine(SlashAttack());
                        break;
                }
            }
            else if (count[pattern] == true && 4 < patternCount )
            {
                switch (pattern)
                {
                    case 0:
                        StartCoroutine(NormalAttack());
                        break;
                    case 1:
                        StartCoroutine(GroundAttack());
                        break;
                    case 2:
                        StartCoroutine(SlashAttack());
                        break;
                    case 3:
                        StartCoroutine(Spin());
                        break;
                    case 4:
                        StartCoroutine(Raise());
                        break;

                }
            }
            else
            {
                StartCoroutine(NormalAttack());
            }
            break;
        }

    }

    IEnumerator NormalAttack()
    {
        yield return new WaitForEndOfFrame();
        currentDamage = MonsterDataManager.instance.bossPhaseTwo.damage;
        isAttack = true;
        anim.SetBool("isAttack", true);
        yield return new WaitForSeconds(0.2f);
        attackObject.SetActive(true);
        yield return new WaitForSeconds(animationClip[0].length - 0.2f);
        anim.SetBool("isAttack", false);
        attackObject.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        isAttack = false;
        yield return null;
    }

    IEnumerator GroundAttack()
    {
        yield return new WaitForEndOfFrame();
        currentDamage = MonsterDataManager.instance.bossPhaseTwo.skills[0].damage;
        StartCoroutine(SkillCoolTime(groundSkillCoolTime, 1));
        attackObject.SetActive(true);
        isAttack = true;
        anim.SetBool("isGroundAttack", true);
        yield return new WaitForSeconds(animationClip[1].length);
        anim.SetBool("isGroundAttack", false);
        attackObject.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        isAttack = false;
        yield return null;
    }

    IEnumerator SlashAttack()
    {
        yield return new WaitForEndOfFrame();
        currentDamage = MonsterDataManager.instance.bossPhaseTwo.skills[1].damage;
        StartCoroutine(SkillCoolTime(slashSkillCoolTime, 2));
        attackObject.SetActive(true);
        isAttack = true;
        anim.SetBool("isSlash", true);
        yield return new WaitForSeconds(animationClip[2].length);
        anim.SetBool("isSlash", false);
        attackObject.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        isAttack = false;
        yield return null;
    }
    IEnumerator Spin()
    {
        yield return new WaitForEndOfFrame();
        currentDamage = MonsterDataManager.instance.bossPhaseTwo.skills[2].damage;
        StartCoroutine(SkillCoolTime(spinSkillCoolTime, 3));
        isAttack = true;
        attackObject.SetActive(true);
        anim.SetBool("isSpin", true);
        yield return new WaitForSeconds(animationClip[4].length * 0.5f);
        anim.SetBool("isSpin", false);
        attackObject.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        isAttack = false;
        yield return null;
    }

    IEnumerator JumpAndSpin()
    {
        yield return new WaitForEndOfFrame();
        currentDamage = MonsterDataManager.instance.bossPhaseTwo.skills[4].damage;
        StartCoroutine(SkillCoolTime(jumpSkillCoolTime, 5));
        isAttack = true;
        nav.isStopped = false;
        nav.SetDestination(transform.position + (transform.forward * 15));
        nav.speed = 11;    
        anim.SetBool("isJump", true);
        attackObject.SetActive(true);
        yield return new WaitForSeconds(animationClip[3].length);
        nav.isStopped = true;
        yield return new WaitForSeconds((animationClip[4].length* 0.5f));
        anim.SetBool("isJump", false);
        nav.speed = 4.0f;
        attackObject.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        isAttack = false;
        yield return null;
    }

    IEnumerator Raise()
    {
        yield return new WaitForEndOfFrame();
        StartCoroutine(SkillCoolTime(riseSkillCoolTime, 4));
        isAttack = true;
        anim.SetBool("isRaise", true);
        yield return new WaitForSeconds(animationClip[5].length + 0.05f);
        bossParticle.Raise();
        yield return new WaitForSeconds((animationClip[6].length * 3));
        anim.SetBool("isRaise", false);
        yield return new WaitForSeconds(animationClip[7].length + 1.0f);
        isAttack = false;
        yield return null;
    }

    IEnumerator SkillCoolTime(float coolTime, int index)
    {
        count[index] = false;
        yield return new WaitForSeconds(coolTime);
        count[index] = true;
        yield return null;
    }

    public void StartJumpAndSpin()
    {
        StartCoroutine(JumpAndSpin());
    }

    
}

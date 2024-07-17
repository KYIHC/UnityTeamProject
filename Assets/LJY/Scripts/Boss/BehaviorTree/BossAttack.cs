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
    #endregion

    #region private 변수
    private bool[] count;
    private float groundSkillCoolTime = 10.0f;
    private float slashSkillCoolTime = 15.0f;
    private Animator anim;
    private NavMeshAgent nav;
    #endregion


    private void OnEnable()
    {
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        count = new bool[5];
        for (int i = 0; i < count.Length; i++)
        {
            count[i] = true;
        }
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
                        StartCoroutine(JumpAndSpin());
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
        isAttack = true;
        anim.SetBool("isAttack", true);
        yield return new WaitForSeconds(0.2f);
        attackObject.SetActive(true);
        yield return new WaitForSeconds(animationClip[0].length - 0.2f);
        anim.SetBool("isAttack", false);
        attackObject.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        isAttack = false;
        yield return null;
    }

    IEnumerator GroundAttack()
    {
        Debug.Log("GroundAttack");
        StartCoroutine(SkillCoolTime(groundSkillCoolTime, 1));
        attackObject.SetActive(true);
        isAttack = true;
        anim.SetBool("isGroundAttack", true);
        yield return new WaitForSeconds(animationClip[1].length);
        anim.SetBool("isGroundAttack", false);
        attackObject.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        isAttack = false;
        yield return null;
    }

    IEnumerator SlashAttack()
    {
        StartCoroutine(SkillCoolTime(slashSkillCoolTime, 2));
        attackObject.SetActive(true);
        isAttack = true;
        anim.SetBool("isSlash", true);
        yield return new WaitForSeconds(animationClip[2].length);
        anim.SetBool("isSlash", false);
        attackObject.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        isAttack = false;
        yield return null;
    }

    IEnumerator JumpAndSpin()
    {
        StartCoroutine(SkillCoolTime(groundSkillCoolTime, 3));
        isAttack = true;
        nav.isStopped = false;
        nav.SetDestination(transform.position + transform.forward * 10);
        nav.speed = 8;
        anim.SetBool("isJump", true);
        attackObject.SetActive(true);
        yield return new WaitForSeconds(animationClip[3].length);
        nav.isStopped = true;
        yield return new WaitForSeconds((animationClip[4].length* 0.5f));
        anim.SetBool("isJump", false);
        nav.speed = 4.0f;
        attackObject.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        isAttack = false;
        yield return null;
    }

    IEnumerator Raise()
    {
        StartCoroutine(SkillCoolTime(slashSkillCoolTime, 4));
        isAttack = true;
        anim.SetBool("isRaise", true);
        yield return new WaitForSeconds(animationClip[5].length + (animationClip[6].length *3));
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
}

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
    private float groundSkillCoolTime = 15.0f;
    private float slashSkillCoolTime = 20.0f;
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

    public void PhaseOneAttack(int patternCount)
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
            else if (count[pattern] == true && patternCount < 6)
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
        yield return new WaitForSeconds(1.0f);
        anim.SetBool("isAttack", false);
        attackObject.SetActive(false);
        yield return new WaitForSeconds(2.0f);
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
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("isGroundAttack", false);
        attackObject.SetActive(false);
        yield return new WaitForSeconds(2.0f);
        isAttack = false;
        yield return null;
    }

    IEnumerator SlashAttack()
    {
        StartCoroutine(SkillCoolTime(slashSkillCoolTime, 2));
        attackObject.SetActive(true);
        isAttack = true;
        anim.SetBool("isSlash", true);
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("isSlash", false);
        attackObject.SetActive(false);
        yield return new WaitForSeconds(2.0f);
        isAttack = false;
        yield return null;
    }

    IEnumerator JumpAndSpin()
    {
        isAttack = true;
        nav.isStopped = false;
        nav.SetDestination(transform.position + transform.forward * 5);
        nav.speed = 10;
        anim.SetBool("isJump", true);
        attackObject.SetActive(true);
        yield return new WaitForSeconds(animationClip[4].length + (animationClip[5].length * 0.8f));
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

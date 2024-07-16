using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    private Animator anim;
    #region public 변수
    public bool isAttack = false;
    public GameObject attackCollider;
    #endregion

    #region private 변수
    private bool[] count;
    private float groundSkillCoolTime = 15.0f;
    private float slashSkillCoolTime = 20.0f;
    #endregion

    private void OnEnable()
    {
        anim = GetComponent<Animator>();
        count = new bool[4];
        for (int i = 0; i < count.Length; i++)
        {
            count[i] = true;
        }
    }

    public void PhaseOneAttack()
    {

        while (isAttack == false)
        {
            int a = Random.Range(0, 2);
            if (!count[0] && !count[1])
            {
                StartCoroutine(NormalAttack());
            }
            else if (count[0] || count[1])
            {
                if (count[a])
                {
                    switch (a)
                    {
                        case 0:
                            StartCoroutine(GroundAttack());
                            break;
                        case 1:
                            StartCoroutine(SlashAttack());
                            break;
                    }
                }
            }
            else
            {
                continue;
            }
            break;
        }

    }

    IEnumerator GroundAttack()
    {
        StartCoroutine(SkillCoolTime(groundSkillCoolTime, 0));
        attackCollider.SetActive(true);
        isAttack = true;
        anim.SetBool("isGroundAttack", true);
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("isGroundAttack", false);
        attackCollider.SetActive(false);
        yield return new WaitForSeconds(2.0f);
        isAttack = false;
        yield return null;
    }

    IEnumerator SlashAttack()
    {
        StartCoroutine(SkillCoolTime(slashSkillCoolTime, 1));
        attackCollider.SetActive(true);
        isAttack = true;
        anim.SetBool("isSlash", true);
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("isSlash", false);
        attackCollider.SetActive(false);
        yield return new WaitForSeconds(2.0f);
        isAttack = false;
        yield return null;

    }

    IEnumerator NormalAttack()
    {
        isAttack = true;
        anim.SetBool("isAttack", true);
        yield return new WaitForSeconds(0.2f);
        attackCollider.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        anim.SetBool("isAttack", false);
        attackCollider.SetActive(false);
        yield return new WaitForSeconds(2.0f);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    private Animator anim;
    #region public 변수
    public bool isAttack = false;
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
            else if (count[0] || count[1] && count[a])
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
            else
            {
                continue;
            }
            break;
        }
    }

    IEnumerator GroundAttack()
    {
        isAttack = true;
        anim.SetBool("isGroundAttack", true);
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("isGroundAttack", false);
        isAttack = false;
        groundSkillCoolTime = 15.0f;
        StartCoroutine(SkillCoolTime(groundSkillCoolTime, 0));
        yield return null;
    }

    IEnumerator SlashAttack()
    {
        isAttack = true;
        anim.SetBool("isSlash", true);
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("isSlash", false);
        isAttack = false;
        StartCoroutine(SkillCoolTime(slashSkillCoolTime, 1));
        yield return null;
    }

    IEnumerator NormalAttack()
    {
        isAttack = true;
        anim.SetBool("isAttack", true);
        yield return new WaitForSeconds(1.3f);
        anim.SetBool("isAttack", false);
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

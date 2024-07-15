using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    private Animator anim;

    public bool isAttack = false;

    private void OnEnable()
    {
        anim = GetComponent<Animator>();
    }

   public IEnumerator BasicAttack()
    {
        isAttack = true;
        anim.SetBool("BasicAttack",true);
        yield return new WaitForSeconds(3.0f);
        anim.SetBool("BasicAttack",false);
        isAttack = false;
        yield return null;
    }   


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class WelcomeNPC : MonoBehaviour
{
    public NavMeshAgent nav;
    public Animator anim;
    public Vector3 originPos;
    public Vector3 targetPos;

    public void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        originPos = transform.position;
        targetPos = new Vector3(originPos.x, originPos.y, originPos.z - 5);
        StartCoroutine(Patrol());

    }
   
    IEnumerator Patrol()
    {

        while (true)
        {
            
            anim.SetBool("isPatrol", true);
            nav.SetDestination(targetPos);
            yield return new WaitForSeconds(5f);
            
            nav.SetDestination(originPos);
            yield return new WaitForSeconds(5f);
            
        }


    }
}

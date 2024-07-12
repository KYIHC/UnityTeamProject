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
    public GameObject player;

    public enum State
    {
        patrol,
        trace,
        talk,
    }
    public void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        originPos = transform.position;
        targetPos = new Vector3(originPos.x, originPos.y, originPos.z - 5);
        SetState(State.patrol);
    }
    public void Update()
    {
        

        


    }
    public void SetState(State state)
    {
        switch (state)
        {
            case State.patrol:
                StartCoroutine(Patrol());
                anim.SetBool("isPatrol", true);
                if (player.transform.position.z - transform.position.z < 5f)
                {                    
                    SetState(State.trace);
                }
                break;
            case State.trace:
                nav.SetDestination(player.transform.position);
                if (player.transform.position.z - transform.position.z < 0.5f)
                {
                    SetState(State.talk);
                }
                break;
            case State.talk:
                anim.SetBool("isPatrol", false);
                anim.SetBool("isTalk", true);
                break;
        }
    }
    IEnumerator Patrol()
    {

        while (player.transform.position.z - transform.position.z < 5f)
        {

            anim.SetBool("isPatrol", true);
            nav.SetDestination(targetPos);
            yield return new WaitForSeconds(5f);

            nav.SetDestination(originPos);
            yield return new WaitForSeconds(5f);

        }


    }
}

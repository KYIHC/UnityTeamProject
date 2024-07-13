using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class NPCController : MonoBehaviour
{
    public Animator anim;
    public NavMeshAgent nav;
    private Vector3 originPos;


    // NPC의 상태를 Enum을 통해서 정의
    public enum NPCState
    {
        Idle,
        Patrol,
        Chase,
    }

    public void Start()
    {
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        SetState(NPCState.Idle);
        originPos = transform.position;
    }

   
    public void SetState(NPCState state)
    {
        switch (state)
        {
            case NPCState.Idle:
                anim.SetBool("isPatrol", false);
                SetState(NPCState.Patrol);
                break;
            case NPCState.Patrol:
                anim.SetBool("isPatrol", true);
                StartCoroutine(Patrol());
                break;
            case NPCState.Chase:
                anim.SetBool("isPatrol", false);

                break;
        }
    }
    IEnumerator Patrol()
    {

        while (true)
        {
            for (int i = 0; i < 3; i++)
            {
                Vector2 randomPoint = Random.insideUnitCircle * 10;
                Vector3 randomPosition = new Vector3(randomPoint.x, 0, randomPoint.y);
                randomPosition += transform.position;
                nav.SetDestination(randomPosition);
                yield return new WaitUntil(() => nav.remainingDistance < 0.1f);
            }
            nav.SetDestination(originPos);
            yield return new WaitUntil(() => nav.remainingDistance < 0.1f);


        }
    }




}

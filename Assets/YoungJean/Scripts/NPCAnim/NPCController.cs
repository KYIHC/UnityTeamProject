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

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetState(NPCState.Patrol);
        }
        else
            {
            SetState(NPCState.Idle);
        }

    }
    public void SetState(NPCState state)
    {
        switch (state)
        {
            case NPCState.Idle:
                anim.SetBool("isIdle", true);
                anim.SetBool("isPatrol", false);
                anim.SetBool("isChase", false);
                break;
            case NPCState.Patrol:
                anim.SetBool("isIdle", false);
                anim.SetBool("isPatrol", true);
                anim.SetBool("isChase", false);

                NPCPatrol();

                break;
            case NPCState.Chase:
                anim.SetBool("isIdle", false);
                anim.SetBool("isPatrol", false);
                anim.SetBool("isChase", true);
                break;
        }
    }
    public void NPCPatrol()
    {
        Vector3 randomPos = Random.insideUnitSphere * 1f;
        randomPos.y = 0;
        Vector3 finalPos = transform.position + randomPos;

        nav.SetDestination(finalPos);
    }


}

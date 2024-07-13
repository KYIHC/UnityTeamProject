using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class WelcomeNPC : MonoBehaviour
{
    private Animator anim;
    private NavMeshAgent nav;
    private GameObject player;
    public enum NPCState
    {
        Idle,
        Walking,
        Talking
    }
    private NPCState state;

    void Start()
    {
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");
        Setstate(NPCState.Idle);

    }

    public void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);
        if (distance < 2) Setstate(NPCState.Talking);
        else if (distance < 10) Setstate(NPCState.Walking);
        else Setstate(NPCState.Idle);

        Debug.Log(state);

    }
   public void Setstate(NPCState nPCState)
    {
        state = nPCState;

        switch (state)
        {
            case NPCState.Idle:
                anim.SetBool("isPatrol", false);
                anim.SetBool("isTalk", false);
                nav.isStopped = true;
                break;
            case NPCState.Walking:
                anim.SetBool("isPatrol", true);
                anim.SetBool("isTalk", false);
                nav.isStopped = false;
                nav.SetDestination(player.transform.position);
                break;
            case NPCState.Talking:
                anim.SetBool("isPatrol", false);
                anim.SetBool("isTalk", true);
                nav.isStopped = true;
                break;
        }
    }



}

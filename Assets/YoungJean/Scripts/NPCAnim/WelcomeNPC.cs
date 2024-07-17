using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


public class WelcomeNPC : MonoBehaviour
{
    private Animator anim;
    private NavMeshAgent nav;
    private GameObject player;
    private DialogueManager theDM;
    public GameObject exit;

    private bool isTalk = false;
    public enum NPCState
    {
        Idle,
        Walking,
        Talking,
        Exit
    }
    private NPCState state;

    void Start()
    {
        anim = GetComponent<Animator>();
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Character");
        theDM = FindObjectOfType<DialogueManager>();
        Setstate(NPCState.Idle);

    }


    public void Update()
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);        
        if (distance < 2 && !isTalk) Setstate(NPCState.Talking);
        else if (distance < 10 && !isTalk) Setstate(NPCState.Walking);
        else if (distance < 2 && isTalk)
        {
            //3초후 Idle로 전환
            Invoke("Setstate", 5);

        }
        else if (distance < 10 && isTalk) Setstate(NPCState.Exit);
        

        
        

    }
  /*  public void Setstate()
    {
        Setstate(NPCState.Idle);
    }*/
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
                //transform.GetComponent<InteractionEvent>().GetDialogue();

                theDM.ShowDialogue(transform.GetComponent<InteractionEvent>().GetDialogue());
                isTalk = true;
                GameObject go = GameObject.Find("GeneralGoodMerchant");
                QuestHelper.instance.target = go.transform;
                QuestHelper.instance.isDraw = true;
                break;
            case NPCState.Exit:
                anim.SetBool("isPatrol", true);
                anim.SetBool("isTalk", false);
                nav.isStopped = false;

                nav.SetDestination(exit.transform.position);
                Destroy(gameObject, 10f);



                break;
        }
    }


}


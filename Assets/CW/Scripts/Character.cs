using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    private Camera camera;
    private Animator anim;
    private Vector3 CharacterMove;
    private NavMeshAgent nav;

    public bool isMove;

    public float Speed=5f;
    
    


    private void Awake()
    {
        camera = Camera.main;
        anim = GetComponentInChildren<Animator>();
        nav = GetComponent<NavMeshAgent>();
        nav.updateRotation = false;
        
    }
    private void Update()
    {
        if(Input.GetMouseButton(1))
        {
            RaycastHit hit;
            if(Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition),out hit))
            {
                
                
                setCharacterMove(hit.point);
                


            }
        }
        LookMoveDir();
    }

    public void setCharacterMove(Vector3 charMove)
    {
        nav.SetDestination(charMove);
        CharacterMove= charMove;
        isMove = true;
        anim.SetBool("isMove",true);

    }

    public void LookMoveDir()
    {
        if(isMove==true)
        {
            if(nav.velocity.magnitude==0f)
            {
                isMove = false;
                anim.SetBool("isMove", false);
                return;                
            }
            var dir = new Vector3(nav.steeringTarget.x,transform.position.y,nav.steeringTarget.z) - transform.position;
            dir.y = 0;
            anim.transform.forward = dir;
            
            
            

            


        }
        
    }



}

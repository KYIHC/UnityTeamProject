using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    private Camera camera;
    private Animator anim;
    private Vector3 CharacterMove;

    public bool isMove;

    public float Speed=5f;
    


    private void Awake()
    {
        camera = Camera.main;
        anim = GetComponentInChildren<Animator>();
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
        Move();
    }

    public void setCharacterMove(Vector3 charMove)
    {
        CharacterMove= charMove;
        isMove = true;
        anim.SetBool("isMove",true);
    }

    public void Move()
    {
        if(isMove==true)
        {
            var dir = CharacterMove - transform.position;
            dir.y = 0;
            anim.transform.forward = dir;
            transform.position += dir.normalized*Time.deltaTime*Speed;
            

            


        }
        if(Vector3.Distance(transform.position,CharacterMove)<=0.1f)
        {
            isMove = false;
            anim.SetBool("isMove", false);
        }
    }



}

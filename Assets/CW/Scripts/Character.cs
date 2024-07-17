using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject[] weapons;


    
    public float stopDistance=1.0f;


    private Animator anim;
    private Vector3 CharacterMove;

    private NavMeshAgent nav;

    public bool[] hasWeapon;
    public bool isMove;
    public bool isAttackReady;
    public bool isRolling;
    public bool attackCheck;
    public bool isRollingReady;

    



    Weapon weapon;
    Vector3 RollingVec;



    float attackDelay;
    float rollingDelay;





    private void Awake()
    {


        isRollingReady = true;


        anim = GetComponentInChildren<Animator>();
        nav = GetComponent<NavMeshAgent>();
        nav.updateRotation = false;

    }
    private void Update()
    {
        if (Input.GetMouseButton(1) && attackCheck == false)
        {

            RaycastHit hit;

            if (Physics.Raycast(mainCamera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                setCharacterMove(hit.point);


            }

        }

        Attack();
        Rolling();
        LookMoveDir();

        

        /*NavMeshAgent[] allAgents = FindObjectsOfType<NavMeshAgent>();
        foreach(NavMeshAgent otherAgent in allAgents)
        {
            if(otherAgent!=nav)
            {
                float distance = Vector3.Distance(nav.transform.position, otherAgent.transform.position);
                if(distance<stopDistance)
                {
                    nav.isStopped = true;
                    return;
                }
            }
        }
        nav.isStopped = false;*/





    }



    public void setCharacterMove(Vector3 charMove)
    {
        nav.isStopped = false;
        nav.SetDestination(charMove);
        CharacterMove = charMove;
        isMove = true;
        anim.SetBool("isMove", true);

    }

    public void LookMoveDir()
    {
        if (isMove == true)
        {
            if (nav.velocity.magnitude == 0f)
            {
                isMove = false;
                anim.SetBool("isMove", false);
                return;
            }
            var dir = new Vector3(nav.steeringTarget.x, transform.position.y, nav.steeringTarget.z) - transform.position;
            dir.y = 0;
            anim.transform.forward = dir;


        }


    }

    public void Attack()
    {
        anim.SetBool("Sword", false);
        int weaponIndex = 0;



        weapon = weapons[weaponIndex].GetComponent<Weapon>();
        weapon.gameObject.SetActive(true);




        attackDelay += Time.deltaTime;
        isAttackReady = weapon.attackSpeed < attackDelay;

        if (Input.GetMouseButton(0) && isAttackReady)
        {
            attackCheck = true;
            weapon.useWeapon();
            switch (weapon.weaponType)
            {
                case Weapon.WeaponType.SWORD:

                    anim.SetBool("Sword",true);
                    break;
            }
            attackDelay = 0;
            

            StartCoroutine(resumeMove());

        }
        
    }

    void Rolling()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isRollingReady && nav.velocity.magnitude > 3f)
        {


            RollingVec = CharacterMove;
            nav.speed = 12;
            anim.SetTrigger("Rolling");
            isRolling = true;

            Invoke("RollingBreak", 0.5f);
            rollingDelay = 0;
            StartCoroutine(rollingInterval());
        }
    }

    void RollingBreak()
    {
        nav.speed *= 0.5f;
        isRolling = false;

    }




    public void ActivateSkill(SOSkill skill)
    {
        attackCheck = true;
        if (attackCheck == true)
        {
            anim.Play(skill.animationName);
            print(string.Format("적에게 스킬{0}로 {1}의 피해를 주었습니다.", skill.name, skill.damage));

        }
        StartCoroutine(resumeMove());

    }

    IEnumerator rollingInterval()
    {

        isRollingReady = false;
        if (isRollingReady == false)
        {
            yield return new WaitForSeconds(5f);
            isRollingReady = true;
        }
        yield return null;
    }



    public void stopMove()
    {
        if (attackCheck == true)
            nav.isStopped = true;
        if (isMove == false)
            nav.isStopped = true;
    }

    IEnumerator resumeMove()
    {
        nav.isStopped = true;
        yield return new WaitForSeconds(0.1f);
        attackCheck = false;

        yield return null;
    }

    

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("trigger enter called");

        if(other.tag=="Monster")
        {
            Debug.Log(other.tag);
            nav.destination = transform.position;

        }
    }

    




}

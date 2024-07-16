using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject[] weapons;
    public bool[] hasWeapon;


    private Animator anim;
    private Vector3 CharacterMove;

    private NavMeshAgent nav;

    public bool isMove;
    public bool isAttackReady;
    public bool isrolling;
    public bool attackCheck;
   


    Weapon weapon;
    Vector3 RollingVec;



    float attackDelay;





    private void Awake()
    {





        anim = GetComponentInChildren<Animator>();
        nav = GetComponent<NavMeshAgent>();
        nav.updateRotation = false;

    }
    private void Update()
    {
        if (Input.GetMouseButton(1) && attackCheck != true)
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




    }



    public void setCharacterMove(Vector3 charMove)
    {
        nav.SetDestination(charMove);
        CharacterMove = charMove;
        isMove = true;
        anim.SetBool("isMove", true);

    }

    public void LookMoveDir()
    {
        if (isMove == true && !attackCheck)
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

        int weaponIndex = 0;



        weapon = weapons[weaponIndex].GetComponent<Weapon>();
        weapon.gameObject.SetActive(true);




        attackDelay += Time.deltaTime;
        isAttackReady = weapon.attackSpeed < attackDelay;

        if (Input.GetMouseButton(0) && isAttackReady && !isMove)
        {
            attackCheck = true;
            weapon.useWeapon();
            switch (weapon.weaponType)
            {
                case Weapon.WeaponType.SWORD:

                    anim.SetTrigger("Sword");
                    break;
            }
            attackDelay = 0;
            Invoke("attackChecking", 1f);

        }

    }

    void Rolling()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (nav.velocity.magnitude > 3f)
            {
                RollingVec = CharacterMove;
                nav.speed = 12;
                anim.SetTrigger("Rolling");
                isrolling = true;

                Invoke("RollingBreak", 0.5f);
            }
        }
    }

    void RollingBreak()
    {
        nav.speed *= 0.5f;
        isrolling = false;
    }


    void attackChecking()
    {
        attackCheck = false;
    }

    public void ActivateSkill(SOSkill skill)
    {


        anim.Play(skill.animationName);
        print(string.Format("적에게 스킬{0}로 {1}의 피해를 주었습니다.", skill.name, skill.damage));


    }


}

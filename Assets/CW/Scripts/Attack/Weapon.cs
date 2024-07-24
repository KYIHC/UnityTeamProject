using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum WeaponType
    {
        SWORD,
        SHIELD
    };

    public WeaponType weaponType;
    public int damage;
    public GameObject weaponArea;
    public float attackSpeed;

    public Character character;

    private void Start()
    {
        character = FindObjectOfType<Character>();

        if(character!=null)
        {
            bool value = character.attackCheck;
            
        }
    }

    public void useWeapon()
    {
        switch (weaponType)
        {
            case WeaponType.SWORD:
                
                    StopCoroutine("UseSword");
                    StartCoroutine("UseSword");
                

                break;

            


        }
    }

    IEnumerator UseSword()
    {
        if (character.isAttackReady==true&&character.attackCheck==true)
        {
            yield return new WaitForSeconds(0.1f);
            weaponArea.SetActive(true);



            yield return new WaitForSeconds(0.3f);
            weaponArea.SetActive(false);
        }
        
    }
    
}

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
    public BoxCollider weaponArea;
    public float attackSpeed;



    public void useWeapon()
    {
        switch(weaponType)
        {
            case WeaponType.SWORD:
                StopCoroutine("UseSword");
                StartCoroutine("UseSword");

                break;

            case WeaponType.SHIELD:
                StopCoroutine("UseShield");
                StartCoroutine("UseShield");
                break;


        }
    }

    IEnumerator UseSword()
    {
        yield return new WaitForSeconds(0.1f);
        weaponArea.enabled = true;

        yield return new WaitForSeconds(0.3f);
        weaponArea.enabled = false;
    }
    IEnumerator UseShield()
    {
        yield return null;
        weaponArea.enabled = true;
        yield return new WaitForSeconds(2f);
        weaponArea.enabled = false;
    }
}

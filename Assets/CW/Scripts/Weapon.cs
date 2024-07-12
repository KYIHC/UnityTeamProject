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



    public void useWeapon()
    {
        switch(weaponType)
        {
            case WeaponType.SWORD:
                StartCoroutine("UseSword");
                StopCoroutine("UseSword");

                break;

            case WeaponType.SHIELD:
                StartCoroutine("UseShield");
                StopCoroutine("UseShield");
                break;


        }
    }

    IEnumerator UseSword()
    {
        yield return new WaitForSeconds(0.5f);
        weaponArea.enabled = true;
        weaponArea.enabled = false;
    }
    IEnumerator UseShield()
    {
        yield return null;
        weaponArea.enabled = true;
        weaponArea.enabled = false;
    }
}

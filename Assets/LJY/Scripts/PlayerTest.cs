using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MonsterSword"))
        {
            Debug.Log("Monster Attack");
        }
    }

}

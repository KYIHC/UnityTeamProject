using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Portal : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.instance.DungeonPhase == 1)
            {
                DungeonManager.instance.GotoPhaseOne();
            }
            else if (GameManager.instance.DungeonPhase == 2)
            {
                DungeonManager.instance.WaitingRoomSpawn();
                DungeonManager.instance.portal[1].SetActive(false);
                GameManager.instance.DungeonPhase++;
            }
            else
            {
                DungeonManager.instance.GotoPhaseTwo();
            }
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonManager : MonoBehaviour
{
    public static DungeonManager instance;

    public short currentPhase;
    public short currentWave;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hpbar : MonoBehaviour
{
    [SerializeField]
    private Slider hpbar;
    


    

    private void Start()
    {
        
        
        hpbar.value= (float)Datamanager.instance.playerData.CurrentHp / (float)Datamanager.instance.playerData.maxHp;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Datamanager.instance.playerData.CurrentHp > 0)
            {
                Datamanager.instance.playerData.CurrentHp -= 10;
            }
            else
            {
                Datamanager.instance.playerData.CurrentHp = 0;
            }
        }
        

        HandleHp();
    }


    void HandleHp()
    {
        hpbar.value=(float)Datamanager.instance.playerData.CurrentHp/ (float)Datamanager.instance.playerData.maxHp;
    }

}

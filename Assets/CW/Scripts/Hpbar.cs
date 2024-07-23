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
        
        
        hpbar.value= (float)PlayerDataManager.instance.playerData.CurrentHp / (float)PlayerDataManager.instance.playerData.maxHp;
    }

    private void Update()
    {
        HandleHp();
    }


    void HandleHp()
    {
        hpbar.value=(float)PlayerDataManager.instance.playerData.CurrentHp/ (float)PlayerDataManager.instance.playerData.maxHp;
    }

}

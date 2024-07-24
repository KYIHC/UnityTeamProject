using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hpbar : MonoBehaviour
{
    [SerializeField]
    private Slider hpbar;
    
    public TextMeshProUGUI HpState;

    public TextMeshProUGUI Name;

    private void Start()
    {
        hpbar.value= PlayerDataManager.instance.playerData.CurrentHp / PlayerDataManager.instance.playerData.maxHp;
    }

    private void Update()
    {
        HandleHp();
        HpStateText();
        GetName();
    }


    void HandleHp()
    {
        hpbar.value=PlayerDataManager.instance.playerData.CurrentHp/ PlayerDataManager.instance.playerData.maxHp;
    }

    void HpStateText()
    {
        HpState.text = $"{PlayerDataManager.instance.playerData.CurrentHp + " / " + PlayerDataManager.instance.playerData.maxHp}";
    }
    void GetName()
    {
        Name.text = PlayerDataManager.instance.playerData.name;
    }
    

}

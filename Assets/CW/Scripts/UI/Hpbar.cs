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
        hpbar.value= Mathf.Max(PlayerDataManager.instance.playerData.CurrentHp,0) / PlayerDataManager.instance.playerData.maxHp;
    }

    private void Update()
    {
        
        HandleHp();
        HpStateText();
        GetName();
    }


    void HandleHp()
    {
        float currentHp = Mathf.Max(PlayerDataManager.instance.playerData.CurrentHp, 0);
        hpbar.value= currentHp / PlayerDataManager.instance.playerData.maxHp;
    }

    void HpStateText()
    {
        float currentHp = Mathf.Max(PlayerDataManager.instance.playerData.CurrentHp, 0);
        HpState.text = $"{currentHp + " / " + PlayerDataManager.instance.playerData.maxHp}";
    }
    void GetName()
    {
        Name.text = PlayerDataManager.instance.playerData.name;
    }
    

}

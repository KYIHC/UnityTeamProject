using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    public Button Exit;
    public TextMeshProUGUI Stat;
    public GameObject StatusPanel;

    bool isOpen = false;

    private void Awake()
    {
        isOpen = false;

        Exit.onClick.AddListener(ExitStatus);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            isOpen = !isOpen;
            StatusPanel.SetActive(isOpen);

            Stat.text =
                "�̸�:" + PlayerDataManager.instance.playerData.name
                + "\nü��:" + PlayerDataManager.instance.playerData.CurrentHp + "/" + PlayerDataManager.instance.playerData.maxHp
                + "\n���ݷ�:" + PlayerDataManager.instance.playerData.attackDamage
                + "\n����:" + PlayerDataManager.instance.playerData.armorDef;
            
                

        }
    }

    public void ExitStatus()
    {
        isOpen = false;
        StatusPanel.SetActive(isOpen);
    }
}

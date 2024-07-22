using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tooltip : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI atkText;
    public TextMeshProUGUI atkValueText;

    public TextMeshProUGUI defText;
    public TextMeshProUGUI defValueText;


    public void SetupTooltip(string name, string description, int cost,int atk, int def)
    {
        nameText.text = name;
        descriptionText.text = description;
        costText.text = cost.ToString();


        if(def > 0)
        {
            defText.gameObject.SetActive(true);
            defValueText.gameObject.SetActive(true);
            defValueText.text = def.ToString();
        }
        else
        {
            defText.gameObject.SetActive(false);
            defValueText.gameObject.SetActive(false);
        }

        if(atk > 0)
        {
            atkText.gameObject.SetActive(true);
            atkValueText.gameObject.SetActive(true);
            atkValueText.text = atk.ToString();
        }
        else
        {
            atkText.gameObject.SetActive(false);
            atkValueText.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        transform.position = new Vector3(Input.mousePosition.x - 60, Input.mousePosition.y + 40, 0);
    }
}

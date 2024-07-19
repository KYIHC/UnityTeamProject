using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseBuff : MonoBehaviour
{
    public string type;
    public float percentage;
    public float duration;
    public float currentTime;
    public Image icon;



    private void Awake()
    {
        
    }

    public void Init(string type,float per, float du)
    {
        this.type = type;
        percentage = per;
        duration = du;
        currentTime = duration;
        icon.fillAmount = 1;


    }

    WaitForSeconds seconds = new WaitForSeconds(0.1f);

    public void Execute()
    {
        StartCoroutine(Activation());


    }

    IEnumerator Activation()
    {
        while(currentTime>0)
        {
            currentTime -= 0.1f;
            icon.fillAmount = currentTime / duration;

            yield return seconds;
        }
        icon.fillAmount = 0;

        DeActivation();
    }

    public void DeActivation()
    {
        Destroy(gameObject);
    }


}

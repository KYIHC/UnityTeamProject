using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffManager : MonoBehaviour
{
    public static BuffManager instance;
    
    public bool canChooseBuff = true;
    
    public GameObject buffPrefab;
    public Animator animator;
    

    public Image cooltimeImg;
    


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;

        }
        instance = this;
    }



    

    

    public void CreateBuff(string type,float per,float du,Sprite icon)
    {
        if (canChooseBuff)
        {
            animator.SetBool("InBuff", true);
            GameObject go = Instantiate(buffPrefab, transform);
            go.GetComponent<BaseBuff>().Init(type, per, du);
            go.GetComponent<Image>().sprite = icon;
        }
        StartCoroutine(BuffCoroutine());
    }

    IEnumerator BuffCoroutine()
    {
        
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("InBuff", false);
        canChooseBuff = false;
        
        float tick = 1f / 20;
        float t = 0;

        cooltimeImg.fillAmount = 1;

        while (cooltimeImg.fillAmount > 0)
        {
            cooltimeImg.fillAmount = Mathf.Lerp(1, 0, t);
            t += (Time.deltaTime * tick);

            yield return null;
        }

        

        
        canChooseBuff = true;
        cooltimeImg.fillAmount = 0;
        
    }

    
}

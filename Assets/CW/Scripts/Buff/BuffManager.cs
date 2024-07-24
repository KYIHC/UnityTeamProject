using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuffManager : MonoBehaviour
{

    public bool canChooseBuff = true;
    public GameObject buffPrefab;
    public Animator animator;
    public Image cooltimeImg;
    public Image rollingCoolTimeImg;
    public GameObject rollingCoolImg;

    private Character character;

    private void Start()
    {
        character = FindObjectOfType<Character>();
        cooltimeImg.fillAmount = 0;
        rollingCoolTimeImg.fillAmount = 0;
    }

    private void Update()
    {
        if (character.isRolling)
        {
            StartCoroutine(RollingUICoroutine());
        }
    }

    public void CreateBuff(string type, float per, float du, Sprite icon)
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

    IEnumerator RollingUICoroutine()
    {

        yield return new WaitForSeconds(0.1f);


        rollingCoolImg.SetActive(true);

        float tick = 1f / 5;
        float t = 0;

        rollingCoolTimeImg.fillAmount = 1;

        while (rollingCoolTimeImg.fillAmount > 0)
        {
            rollingCoolTimeImg.fillAmount = Mathf.Lerp(1, 0, t);
            t += (Time.deltaTime * tick);

            yield return null;
        }




        if (character.isRollingReady == true)
        {
            rollingCoolTimeImg.fillAmount = 0;
            rollingCoolImg.SetActive(false);
        }
        


    }



}

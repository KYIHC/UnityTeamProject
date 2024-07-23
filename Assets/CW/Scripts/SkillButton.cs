using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    public SOSkill skill;

    public Character character;

    public Image skillIcon;

    public Image cooltimeImg;

    public KeyCode activationKey;

    private bool isCoolingDown = false;

    public bool SkillCheck;





    private void Start()
    {
        skillIcon.sprite = skill.icon;
        cooltimeImg.fillAmount = 0;
        


    }
    private void Update()
    {
        if (Input.GetKeyDown(activationKey))
        {
            SkillSlot();
            

        }


        
        
    }

    public void SkillSlot()
    {
        
            if (isCoolingDown)
                return;

            character.ActivateSkill(skill);

            StartCoroutine(SC_Cool());
        
    }
    

    IEnumerator SC_Cool()
    {
        isCoolingDown = true;
        float tick = 1f / skill.coolTime;
        float t = 0;

        cooltimeImg.fillAmount = 1;

        while(cooltimeImg.fillAmount>0)
        {
            cooltimeImg.fillAmount = Mathf.Lerp(1, 0, t);
            t += (Time.deltaTime * tick);

            yield return null;
        }

        cooltimeImg.fillAmount = 0;
        isCoolingDown = false;

    }

}

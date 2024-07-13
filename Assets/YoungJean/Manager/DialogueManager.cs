using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject go_DialogueBar;
    [SerializeField] GameObject go_DialogueNameBar;

    [SerializeField] Text txt_Dialogue;
    [SerializeField] Text txt_Name;

    Dialogue[] dialogues;
    bool isDialogue = false;//대화중일 경우 true
    bool isNext = false;//특정 키 입력 대기

    int lineCount = 0;//대화카운트
    int contextCount = 0;//대사 카운트
    
    public void ShowDialogue(Dialogue[] p_dialogues)
    {
        txt_Dialogue.text = "";
        txt_Name.text = "";
        dialogues = p_dialogues;

        StartCoroutine(TypeWriter());
    }
    IEnumerator TypeWriter()
    {
        SettingUI(true);        
        string t_ReplaceText = dialogues[lineCount].contexts[lineCount];
        t_ReplaceText = t_ReplaceText.Replace("'", ",");

        txt_Dialogue.text = t_ReplaceText;

        isNext = true;
        yield return null;
    }

    void SettingUI(bool p_flag)
    {
     
        go_DialogueBar.SetActive(p_flag);
        go_DialogueNameBar.SetActive(p_flag);
    }

   
}

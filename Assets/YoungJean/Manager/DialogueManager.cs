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
    bool isDialogue = false;//��ȭ���� ��� true
    bool isNext = false;//Ư�� Ű �Է� ���

    int lineCount = 0;//��ȭī��Ʈ
    int contextCount = 0;//��� ī��Ʈ
    
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

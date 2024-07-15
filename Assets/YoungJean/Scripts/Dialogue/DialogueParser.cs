using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParser : MonoBehaviour
{
    public Dialogue[] Parse(string _CSVfileName)
    {
        List<Dialogue> dialogueList = new List<Dialogue>();//��� ����Ʈ ����.
        TextAsset csvData = Resources.Load<TextAsset>(_CSVfileName);//CSV���� �ε�.

        string[] data = csvData.text.Split(new char[] { '\n' });//CSV������ ���پ� �о data�� ����.

        for (int i = 1; i < data.Length;)
        {
            string[] row = data[i].Split(new char[] { ',' });//������ ,�� ������ row�� ����.

            Dialogue dialogue = new Dialogue();//��� Ŭ���� ����.

            dialogue.name = row[1];//��� Ŭ������ �̸��� row�� 0��° �ε��� ����.            
            List<string> contextList = new List<string>();//��� ���� ����Ʈ ����.
            do 
            { 
                contextList.Add(row[2]);                
                if (++i < data.Length) row = data[i].Split(new char[] { ',' }); 
                else break; 
            }  

            while (row[0].ToString() == "");

            dialogue.contexts = contextList.ToArray();//��� Ŭ������ ��� ���뿡 contextList�� �迭�� ��ȯ�Ͽ� ����.
            
            dialogueList.Add(dialogue);//��� ����Ʈ�� ��� Ŭ���� �߰�.
        }
        return dialogueList.ToArray();
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParser : MonoBehaviour
{
    public Dialogue[] Parse(string _CSVfileName)
    {
        List<Dialogue> dialogueList = new List<Dialogue>();//대사 리스트 생성.
        TextAsset csvData = Resources.Load<TextAsset>(_CSVfileName);//CSV파일 로드.

        string[] data = csvData.text.Split(new char[] { '\n' });//CSV파일을 한줄씩 읽어서 data에 저장.

        for (int i = 1; i < data.Length;)
        {
            string[] row = data[i].Split(new char[] { ',' });//한줄을 ,로 나눠서 row에 저장.

            Dialogue dialogue = new Dialogue();//대사 클래스 생성.

            dialogue.name = row[1];//대사 클래스의 이름에 row의 0번째 인덱스 저장.            
            List<string> contextList = new List<string>();//대사 내용 리스트 생성.
            do 
            { 
                contextList.Add(row[2]);                
                if (++i < data.Length) row = data[i].Split(new char[] { ',' }); 
                else break; 
            }  

            while (row[0].ToString() == "");

            dialogue.contexts = contextList.ToArray();//대사 클래스의 대사 내용에 contextList를 배열로 변환하여 저장.
            
            dialogueList.Add(dialogue);//대사 리스트에 대사 클래스 추가.
        }
        return dialogueList.ToArray();
    }

    
}

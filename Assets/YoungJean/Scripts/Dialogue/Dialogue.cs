using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [Tooltip("말하는 사람")]
    public string name;

    [Tooltip("말하는 내용")]
    public string[] contexts;
}
[System.Serializable]
public class DialougeEvent
{
    public string name;// Event 이름

    public Vector2 line; // 대화를 시작할 라인
    public Dialogue[] dialogues;

}
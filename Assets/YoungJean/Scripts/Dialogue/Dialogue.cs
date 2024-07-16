using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [Tooltip("���ϴ� ���")]
    public string name;

    [Tooltip("���ϴ� ����")]
    public string[] contexts;
}
[System.Serializable]
public class DialougeEvent
{
    public string name;// Event �̸�

    public Vector2 line; // ��ȭ�� ������ ����
    public Dialogue[] dialogues;

}
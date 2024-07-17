using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class QuestHelper : MonoBehaviour
{
    public NavMeshAgent nav;
    public Transform target;
    public LineRenderer lineRenderer;


    private void Update()
    {
        DrawPath();
    }

    public void DrawPath()
    {
        NavMeshPath path = new NavMeshPath(); // ��θ� ������ ��ü ����
        nav.CalculatePath(target.position, path); // ��� ���
        lineRenderer.positionCount = path.corners.Length; // ����� �ڳ� ������ŭ ���� �������� �� ���� ����
        lineRenderer.SetPositions(path.corners); // ����� �ڳ� ��ġ�� ���� �������� ������ ����

    }
}

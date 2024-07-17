using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class QuestHelper : MonoBehaviour
{
    public NavMeshAgent nav;
    public Transform target;
    public LineRenderer lineRenderer;
    public bool isDraw = false;

    public static QuestHelper instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    private void Update()
    {
        if(isDraw)
        DrawPath();
    }

    public void DrawPath()
    {
        NavMeshPath path = new NavMeshPath(); // 경로를 저장할 객체 생성
        nav.CalculatePath(target.position, path); // 경로 계산
        lineRenderer.positionCount = path.corners.Length; // 경로의 코너 개수만큼 라인 렌더러의 점 개수 설정
        lineRenderer.SetPositions(path.corners); // 경로의 코너 위치를 라인 렌더러의 점으로 설정

    }
}

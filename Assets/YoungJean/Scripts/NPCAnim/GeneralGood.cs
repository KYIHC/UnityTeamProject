using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GeneralGood : MonoBehaviour
{
    GameObject player;

    private void Start()
    {
        player = GameObject.Find("Character");
    }
    private void Update()
    {
        
      if(Vector3.Distance(player.transform.position, transform.position) < 2&&Input.GetKeyDown(KeyCode.F))
      {
        Debug.Log("F pressed");
      }
      else if(Vector3.Distance(player.transform.position, transform.position) < 10)
      {
            //라인랜더러 해제
            QuestHelper.instance.lineRenderer.positionCount = 0;
            QuestHelper.instance.isDraw = false;
      }
      else
      {
        // do something else
      }   
    }
}

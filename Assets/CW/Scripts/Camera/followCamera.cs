using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class followCamera : MonoBehaviour
{
    float x, z;

    private Transform target;
    public Vector3 offset;
    public Vector3 rotationOffset;



    Vector3 characterLook;


    private void Start()
    {
       
        GameObject player = GameObject.FindWithTag("Player");
        if(player!=null)
        {
            target = player.transform;
        }
        
    }

    private void Update()
    {
        if (target != null)
        {

            Vector3 characterLook = new Vector3(target.position.x, 0,target.position.z).normalized;
            transform.position = target.position + offset;
            target.transform.LookAt(target.transform.position + characterLook);
            Quaternion rotation = Quaternion.Euler(rotationOffset);
            transform.rotation = rotation * Quaternion.LookRotation(target.position - transform.position);
        }

    }

    
}
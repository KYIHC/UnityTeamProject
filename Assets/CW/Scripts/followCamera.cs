using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCamera : MonoBehaviour
{
    float x, z;

    public Transform target;
    public Vector3 offset;
    public Vector3 rotationOffset;
    
    

    Vector3 characterLook;

    private void Update()
    {
        if (target != null)
        {
            
            Vector3 characterLook = new Vector3(x, 0, z).normalized;
            transform.position = target.position + offset;
            target.transform.LookAt(target.transform.position + characterLook);
            Quaternion rotation = Quaternion.Euler(rotationOffset);
            transform.rotation = rotation * Quaternion.LookRotation (target.position - transform.position);
        }

    }
}

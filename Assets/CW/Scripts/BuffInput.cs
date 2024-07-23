using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffInput : MonoBehaviour
{
    public string type;
    public float per;
    public float duration;
    public Sprite icon;

    public BuffManager buffmanager;


    private void Start()
    {
        buffmanager = FindObjectOfType<BuffManager>();
        
    }


    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            buffmanager.CreateBuff(type, per, duration, icon);
            

        }
        




    }

    


}

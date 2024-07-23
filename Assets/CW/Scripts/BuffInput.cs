using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffInput : MonoBehaviour
{
    public string type;
    public float per;
    public float duration;
    public Sprite icon;

    



    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.C))
        {

            BuffManager.instance.CreateBuff(type, per, duration, icon);

        }
        




    }

    


}

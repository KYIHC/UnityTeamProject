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

    Character character;


    private void Start()
    {
        buffmanager = FindObjectOfType<BuffManager>();
        character = FindObjectOfType<Character>();
        
    }


    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.C)&&!character.isMove)
        {
            SoundManager.instance.PlayBuffSound();
            buffmanager.CreateBuff(type, per, duration, icon);
            
            

        }
        




    }

    


}

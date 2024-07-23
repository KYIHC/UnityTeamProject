using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaticleManager : MonoBehaviour
{
    Character character;

    public void PaticleAttack()
    {
        character = GetComponentInParent<Character>();
        character.Attack();
        
    }

    



    


}

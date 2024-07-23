using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaticleManager : MonoBehaviour
{
    public GameObject[] paticle;

    public void normalAttackPaticle()
    {
        Instantiate(paticle[0]);
    }


}

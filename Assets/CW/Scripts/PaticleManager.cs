using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaticleManager : MonoBehaviour
{
    public GameObject normalAttackpaticle;

    private int poolSize = 100;

    private List<GameObject> pools = new List<GameObject>();

    private void Start()
    {
        for(int i=0;i<poolSize;i++)
        {
            GameObject obj = Instantiate(normalAttackpaticle);
            obj.SetActive(false);
            pools.Add(obj);
        }
    }

    public GameObject GetObject(Vector3 position,Quaternion rotation)
    {
        foreach(var obj in pools)
        {
            if(!obj.activeInHierarchy)
            {
                obj.transform.position = position;
                obj.transform.rotation = rotation;
                obj.SetActive(true);
                return obj;
            }
        }
        return null;
    }
    public void ReturnObjectToPool(GameObject obj)
    {
        obj.SetActive(false);
    }

    



    


}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class MObjectPooling : MonoBehaviour
{
    public static MObjectPooling Instance;

    public List<MonsterProjectile> targetObject = new List<MonsterProjectile>();
    public Dictionary<int, Queue<MonsterProjectile>> objectPools = new Dictionary<int, Queue<MonsterProjectile>>();

    private int count = 8;
    private void Awake()
    {
        Instance = this;
        Initalize(count);
    }
    private void Initalize(int count)
    {
        for (int i = 0; i < targetObject.Count; i++)
        {
            for (int j = 0; j < count; j++)
            {
                if (!objectPools.TryGetValue(i, out Queue<MonsterProjectile> queue))
                {
                    queue = new Queue<MonsterProjectile>();
                    objectPools.Add(i, queue);
                    Debug.Log(objectPools[i]);
                    
                }
                objectPools[i].Enqueue(CreateParticle(i));
                Debug.Log(objectPools[0]);
            }
        }
    }
    private MonsterProjectile CreateParticle(int index)
    {
        var obj = Instantiate(targetObject[index]).GetComponent<MonsterProjectile>();
        obj.gameObject.SetActive(false);
        return obj;
    }

    public static MonsterProjectile GetObject(int index)
    {
       
        if (Instance.objectPools[index].Count > 0)
        {
            var obj = Instance.objectPools[index].Dequeue();
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            var obj = Instance.CreateParticle(index);
            obj.gameObject.SetActive(true);
            return obj;
        }


    }

    public void ReturnObject(int index, MonsterProjectile projectile)
    {
        projectile.gameObject.SetActive(false);
        objectPools[index].Enqueue(projectile);
    }
}

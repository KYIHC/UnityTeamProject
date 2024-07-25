using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    public GameObject respawn;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Village")
        {
            
            if (PlayerDataManager.instance.isFirst)
            {
                transform.position = new Vector3(78, 0, -31);
                PlayerDataManager.instance.isFirst = false;
            }
            else
            {
                transform.position = respawn.transform.position;
                transform.rotation = respawn.transform.rotation;
                agent.enabled = true;



            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

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
    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        //컴포넌트를 잠시 꺼놓는다.
        agent.enabled = false;
    }
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Village")
        {
            
            if (PlayerDataManager.instance.isFirst)
            {
                transform.position = new Vector3(78, 0, -31);
                PlayerDataManager.instance.isFirst = false;
                agent.enabled = true;
            }
            else
            {
                transform.position = respawn.transform.position;
                transform.rotation = respawn.transform.rotation;
                agent.enabled = true;
               



            }

        }

    }

    
}

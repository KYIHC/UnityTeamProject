using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    private void Start()
    {
        // ÇöÀç¾ÀÀÌ 
        if (SceneManager.GetActiveScene().name == "Character Scene")
        {
            SceneManager.LoadScene("Village");

        }

    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Village")
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 1);
            foreach (var collider in colliders)
            {
                if (collider.CompareTag("Player"))
                {
                    SceneManager.LoadScene("Dungeon");                }
            }

        }
       
    }
}

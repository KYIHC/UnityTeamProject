using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    public GameObject DungeonPanel;
    public Button EnterButton;
    public Button CancelButton;

    public GameObject player;

    bool panelDelay;

    private void Start()
    {

        // ÇöÀç¾ÀÀÌ 
        if (SceneManager.GetActiveScene().name == "Character Scene")
        {
            SceneManager.LoadScene("Village");

        }
        panelDelay = true;
       




    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Village")
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 3);
            foreach (var collider in colliders)
            {
                if (collider.CompareTag("Player") && panelDelay)
                {

                    DungeonPanel.SetActive(true);

                }
            }

        }

    }

    public void EnterDungeon()
    {


        panelDelay = false;
        DungeonPanel.SetActive(false);
        SceneManager.LoadScene("Dungeon");
    }
    public void CancelDungeon()
    {
        panelDelay = false;
        DungeonPanel.SetActive(false);
        StartCoroutine(PanelDelay());

    }

    public IEnumerator PanelDelay()
    {
        yield return new WaitForSeconds(1f);
        panelDelay = true;
    }
}

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
    
    public GameObject Player;
    public GameObject respawn;
    bool panelDelay;
    
    private void Start()
    {
        
        // 현재씬이 
        if (SceneManager.GetActiveScene().name == "Character Scene")
        {
            SceneManager.LoadScene("Village");

        }
        panelDelay= true;
        if(SceneManager.GetActiveScene().name == "Village")
        {
            if(PlayerDataManager.instance.isDungeon)// 던전에서 왔다면,
            {
                Player.transform.position = respawn.transform.position;
                PlayerDataManager.instance.isDungeon = false;
            }
            
        }
        
       
        

    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Village")
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 3);
            foreach (var collider in colliders)
            {
                if (collider.CompareTag("Player")&&panelDelay)
                {
                    
                    DungeonPanel.SetActive(true);
                    
                }
            }

        }

    }

    public void EnterDungeon()
    {
        
        PlayerDataManager.instance.isDungeon = true;
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

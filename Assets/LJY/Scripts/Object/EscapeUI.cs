using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscapeUI : MonoBehaviour
{
    public Button escapeButton;
    public GameObject escapeUI;
    
    public void OnClickEscapeButton()
    {
        SceneManager.LoadScene("Village");
    }

    public void OnClickCancelButton()
    {
        escapeUI.SetActive(false);
    }
}

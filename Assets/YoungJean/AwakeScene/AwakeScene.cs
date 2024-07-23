using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//¾À¸Å´ÏÀú
using UnityEngine.SceneManagement;

public class AwakeScene : MonoBehaviour
{
    public void onGameStartButtonClick()
    {
        SceneManager.LoadScene("Character Scene");
    }
    public void onExitbuttonClick()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBPLAYER
        Application.OpenURL("http://google.com");
#else
        Application.Quit();
#endif
    }
}

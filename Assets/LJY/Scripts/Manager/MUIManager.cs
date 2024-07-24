using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MUIManager : MonoBehaviour
{
    public static MUIManager instance;

    public GameObject MonsterUI;
    public Image hpbar;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI monsterName;
    public Image monsterImage;
    public Sprite[] MonsterSprite;

    public GameObject BossUI;
    public Image bossHpBar;
    public TextMeshProUGUI bossHpText;
    public TextMeshProUGUI bossName;

    public Image SceneImage;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

}

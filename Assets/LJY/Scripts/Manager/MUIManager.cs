using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MUIManager : MonoBehaviour
{
    public static MUIManager instance;
    #region public 변수
    public GameObject MonsterUI;
    public Image hpbar;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI monsterName;
    public Image monsterImage;
    public Sprite[] MonsterSprite;
    #endregion
    #region private 변수
    public GameObject BossUI;
    public Image bossHpBar;
    public TextMeshProUGUI bossHpText;
    public TextMeshProUGUI bossName;
    #endregion
    public GameObject escapeUI;
    public GameObject clear;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

}

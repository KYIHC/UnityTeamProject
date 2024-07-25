using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MUIManager : MonoBehaviour
{
    public static MUIManager instance;

    #region 몬스터 변수
    public GameObject MonsterUI;
    public Image hpbar;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI monsterName;
    public Image monsterImage;
    public Sprite[] MonsterSprite;
    #endregion

    #region 보스 변수
    public GameObject BossUI;
    public Image bossHpBar;
    public TextMeshProUGUI bossHpText;
    public TextMeshProUGUI bossName;
    #endregion
    public GameObject escapeUI;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

}

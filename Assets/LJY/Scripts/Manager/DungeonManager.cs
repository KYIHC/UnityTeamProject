using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DungeonManager : MonoBehaviour
{
    public static DungeonManager instance;

    public short currentPhase;
    public short currentWave;
    public short phaseCheck;
    public bool waveClear = false;
    public bool phaseOneClear = false;
    public Transform[] spawnPoint;
    public List<GameObject> stage;
    public GameObject[] portal;

    private Vector3 spawnPosition;
    private GameObject player;
    private NavMeshAgent nav;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        phaseCheck = GameManager.instance.DungeonPhase;
    }

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        nav = player.GetComponent<NavMeshAgent>();
        currentWave = 8;

        if (phaseCheck == 0)
        {
            GotoMStage();
        }
        else if (phaseCheck == 1)
        {
            GotoPhaseOne();
        }
        else if (phaseCheck == 2)
        {
            WaitingRoomSpawn();
        }
        SoundManager.instance.musicSource.clip = MSoundManager.instance.dungeonBGM[0];
        SoundManager.instance.musicSource.Play();
        

    }

    private void Update()
    {
        if (waveClear == false && currentWave == 0)
        {
            GameManager.instance.DungeonPhase++;
            portal[0].SetActive(true);
            waveClear = true;
        }
        else if (phaseOneClear == true)
        {
            GameManager.instance.DungeonPhase++;
            portal[1].SetActive(true);
            portal[2].SetActive(true);
            portal[3].SetActive(false);
            phaseOneClear = false;
        }
    }

    public void GotoMStage()
    {
        stage[0].SetActive(true);
        stage[1].SetActive(false);
        stage[2].SetActive(false);
        nav.enabled = false;
        player.transform.position = spawnPoint[0].position;
        player.transform.forward = spawnPoint[0].forward;
        nav.enabled = true;
    }

    public void GotoPhaseOne()
    {
        MUIManager.instance.SceneImage.CrossFadeAlpha(255f, 0.75f, false);
        stage[0].SetActive(false);
        stage[1].SetActive(true);
        stage[2].SetActive(false);
        stage[2].SetActive(false);
        stage[4].SetActive(false);
        nav.enabled = false;
        player.transform.position = spawnPoint[1].position;
        player.transform.forward = spawnPoint[1].forward;
        MUIManager.instance.SceneImage.CrossFadeAlpha(0f, 0.75f, false);
        nav.enabled = true;
    }

    public void WaitingRoomSpawn()
    {
        MUIManager.instance.SceneImage.CrossFadeAlpha(0f, 0.75f, false);
        nav.enabled = false;
        stage[0].SetActive(false);
        stage[1].SetActive(true);
        stage[2].SetActive(true);
        stage[3].SetActive(false);
        stage[4].SetActive(true);
        PlayerDataManager.instance.playerData.CurrentHp = PlayerDataManager.instance.playerData.maxHp;
        player.transform.position = spawnPoint[2].position;
        player.transform.forward = spawnPoint[2].forward;
        MUIManager.instance.SceneImage.CrossFadeAlpha(0f, 0.75f, false);
        nav.enabled = true;
    }

    public void GotoPhaseTwo()
    {
        MUIManager.instance.SceneImage.CrossFadeAlpha(0f, 0.75f, false);
        stage[0].SetActive(false);
        stage[1].SetActive(false);
        stage[2].SetActive(true);
        stage[3].SetActive(false);
        stage[4].SetActive(false);
        nav.enabled = false;
        player.transform.position = spawnPoint[3].position;
        player.transform.forward = spawnPoint[3].forward;
        MUIManager.instance.SceneImage.CrossFadeAlpha(0f, 0.75f, false);
        nav.enabled = true;
    }
}

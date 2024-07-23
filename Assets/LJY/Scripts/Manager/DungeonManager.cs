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
        currentWave = 15;

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
    }

    private void Update()
    {
        if (waveClear == false && currentWave == 0)
        {
            GameManager.instance.DungeonPhase++;
            portal[0].SetActive(true);
            waveClear = false;
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
        stage[0].SetActive(false);
        stage[1].SetActive(true);
        stage[2].SetActive(false);
        stage[2].SetActive(false);
        stage[4].SetActive(false);
        nav.enabled = false;
        player.transform.position = spawnPoint[1].position;
        player.transform.forward = spawnPoint[1].forward;
        nav.enabled = true;
    }

    public void WaitingRoomSpawn()
    {
        stage[0].SetActive(false);
        stage[1].SetActive(true);
        stage[2].SetActive(true);
        stage[3].SetActive(false);
        stage[4].SetActive(true);
        player.transform.position = spawnPoint[2].position;
        player.transform.forward = spawnPoint[2].forward;
    }

    public void GotoPhaseTwo()
    {
        stage[0].SetActive(false);
        stage[1].SetActive(false);
        stage[2].SetActive(true);
        stage[3].SetActive(false);
        stage[4].SetActive(false);
        nav.enabled = false;
        player.transform.position = spawnPoint[3].position;
        player.transform.forward = spawnPoint[3].forward;
        nav.enabled = true;
    }
}
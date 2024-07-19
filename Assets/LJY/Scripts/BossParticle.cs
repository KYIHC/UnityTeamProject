using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BossParticle : MonoBehaviour
{
    public ParticleSystem[] bossParticle;
    public Transform slashPosition;
    public Transform spinPosition;
    public Transform slamPosition;

    public void Slash()
    {
        bossParticle[0].transform.position = slashPosition.position;
        bossParticle[0].transform.rotation = slashPosition.rotation;
        bossParticle[0].transform.forward = slashPosition.forward;
        Instantiate(bossParticle[0]);
        bossParticle[0].Play();
    }

    public void Spin()
    {
        bossParticle[1].transform.position = spinPosition.position;
        bossParticle[1].transform.rotation = spinPosition.rotation;
        bossParticle[1].transform.forward = spinPosition.forward;
        Instantiate(bossParticle[1]);
        bossParticle[1].Play();
    }

    public void Slam()
    {
        bossParticle[2].transform.position = slamPosition.position;
        bossParticle[2].transform.rotation = slamPosition.rotation;
        bossParticle[2].transform.forward = slamPosition.forward;
        Instantiate(bossParticle[2]);
        bossParticle[2].Play();
    }

    public void Attack()
    {
        bossParticle[3].transform.position = slashPosition.position;
        bossParticle[3].transform.rotation = slashPosition.rotation;
        bossParticle[3].transform.forward = slashPosition.forward;
        Instantiate(bossParticle[3]);
        bossParticle[3].Play();
    }

}

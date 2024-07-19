using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerTest : MonoBehaviour
{

    public ParticleSystem[] slashParticle;
    public Transform particlePosition;

    public void LeftSlash()
    {
        Vector3 forwardPosition = particlePosition.position + particlePosition.forward;
        Instantiate(slashParticle[0], forwardPosition, slashParticle[0].transform.rotation);
        slashParticle[0].Play();
       
    }
    public void RightSlash()
    {
        Vector3 forwardPosition = particlePosition.position + particlePosition.forward;
        Instantiate(slashParticle[0], forwardPosition, slashParticle[1].transform.rotation);
        slashParticle[1].Play();
        
    }
    public void UpSlash()
    {
        Vector3 forwardPosition = particlePosition.position + particlePosition.forward;
        Instantiate(slashParticle[0], forwardPosition, slashParticle[2].transform.rotation);
        slashParticle[2].Play();
    }
    public void DownSlash()
    {
        Vector3 forwardPosition = particlePosition.position + particlePosition.forward;
        Instantiate(slashParticle[0], forwardPosition, slashParticle[3].transform.rotation);
        slashParticle[3].Play();
        
    }

}

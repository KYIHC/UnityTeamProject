using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BossParticle : MonoBehaviour
{
    public ParticleSystem[] bossParticle;
    public GameObject raiseDrop;
    public Transform slashPosition;
    public Transform spinPosition;
    public Transform slamPosition;
    public Transform raisePosition;
    public Transform dropPosition;
    public Transform attackGroundPostion;

    private ParticleSystem raiseParticle;

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

    public void Raise()
    {
        bossParticle[4].transform.position = raisePosition.position;
        bossParticle[4].transform.rotation = raisePosition.rotation;
        raiseParticle = Instantiate(bossParticle[4]);
        raiseParticle.Play();

        StartCoroutine(StopParticleAfterDelay(4.2f,4));
    }

    public void RaiseDown()
    {
        var raise = MObjectPooling.GetObject(0);
        Vector3 randomOffset = new Vector3(Random.Range(-5f, 5f), 0f, 0f);
        raise.transform.position = dropPosition.position + randomOffset;
        raise.transform.rotation = dropPosition.rotation;
        raise.Shoot(); 
    }

    public void AttackGround()
    {
        bossParticle[5].transform.position = attackGroundPostion.position;
        bossParticle[5].transform.rotation = attackGroundPostion.rotation;
        Instantiate(bossParticle[5]);
        bossParticle[5].Play();
    
    }
    private IEnumerator StopParticleAfterDelay(float delay, int index)
    {
        yield return new WaitForSeconds(delay);
        raiseParticle.Stop();
        Destroy(raiseParticle.gameObject, 3);
    }
}

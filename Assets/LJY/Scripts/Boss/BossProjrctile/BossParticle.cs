using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BossParticle : MonoBehaviour
{
    #region public 변수
    public ParticleSystem[] bossParticle;
    public GameObject raiseDrop;
    public Transform slashPosition;
    public Transform spinPosition;
    public Transform slamPosition;
    public Transform raisePosition;
    public Transform dropPosition;
    public Transform attackGroundPostion;
    #endregion
    #region private 변수
    private ParticleSystem raiseParticle;
    private ParticleSystem slashParticle;
    private ParticleSystem spinParticle;
    private ParticleSystem slamParticle;
    private ParticleSystem attackGroundParticle;
    #endregion

    public void Slash()
    {
        MSoundManager.instance.audioSource.clip = MSoundManager.instance.bossAudio[2];
        MSoundManager.instance.audioSource.Play();
        bossParticle[0].transform.position = slashPosition.position;
        bossParticle[0].transform.rotation = slashPosition.rotation;
        bossParticle[0].transform.forward = slashPosition.forward;
        slashParticle = Instantiate(bossParticle[0]);
        slashParticle.Play();
        Destroy(slashParticle.gameObject, 5);
    }

    public void Spin()
    {
        MSoundManager.instance.audioSource.clip = MSoundManager.instance.bossAudio[3];
        MSoundManager.instance.audioSource.Play();
        bossParticle[1].transform.position = spinPosition.position;
        bossParticle[1].transform.rotation = spinPosition.rotation;
        bossParticle[1].transform.forward = spinPosition.forward;
        spinParticle = Instantiate(bossParticle[1]);
        spinParticle.Play();
        Destroy(spinParticle.gameObject, 3);
    }

    public void Slam()
    {
        MSoundManager.instance.audioSource.clip = MSoundManager.instance.bossAudio[1];
        MSoundManager.instance.audioSource.Play();
        bossParticle[2].transform.position = slamPosition.position;
        bossParticle[2].transform.rotation = slamPosition.rotation;
        bossParticle[2].transform.forward = slamPosition.forward;
        slamParticle = Instantiate(bossParticle[2]);
        slamParticle.Play();
        Destroy(slamParticle.gameObject, 3);
    }

    public void Attack()
    {
        MSoundManager.instance.audioSource.clip = MSoundManager.instance.bossAudio[0];
        MSoundManager.instance.audioSource.Play();
        var attack = MObjectPooling.GetObject(2);
        attack.transform.position = slashPosition.position;
        attack.transform.rotation = slashPosition.rotation;
        attack.transform.forward = slashPosition.forward;
 
    }

    public void Raise()
    {
        bossParticle[3].transform.position = raisePosition.position;
        bossParticle[3].transform.rotation = raisePosition.rotation;
        raiseParticle = Instantiate(bossParticle[3]);
        raiseParticle.Play();
        StartCoroutine(StopParticleAfterDelay(4.2f,4));
    }

    public void RaiseDown()
    {
        var raise = MObjectPooling.GetObject(0);
        Vector3 randomOffset = new Vector3(Random.Range(-5f, 5f), 0f, Random.Range(-5f, 5f));
        raise.transform.position = dropPosition.position + randomOffset;
        raise.transform.rotation = dropPosition.rotation;
        raise.Shoot(); 
    }

    public void AttackGround()
    {
        MSoundManager.instance.audioSource.clip = MSoundManager.instance.bossAudio[0];
        MSoundManager.instance.audioSource.Play();
        bossParticle[4].transform.position = attackGroundPostion.position;
        bossParticle[4].transform.rotation = attackGroundPostion.rotation;
        attackGroundParticle = Instantiate(bossParticle[4]);
        attackGroundParticle.Play();
        Destroy(attackGroundParticle.gameObject, 3);
    }
    private IEnumerator StopParticleAfterDelay(float delay, int index)
    {
        yield return new WaitForSeconds(delay);
        raiseParticle.Stop();
        Destroy(raiseParticle.gameObject, 3);
    }
}

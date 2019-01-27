using System;
using System.Collections;
using UnityEngine;


public class PlayerParty : MonoBehaviour {
    public GameObject fireworks;


    public void AnimateCompletion(Action callback) {
        if ( fireworks ) {
            StartCoroutine(PlayFireworks(callback));  
        }
    }

    IEnumerator PlayFireworks(Action callback) {
        foreach ( ParticleSystem firework in fireworks.GetComponentsInChildren<ParticleSystem>() ) {
            firework.Play();
            firework.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(UnityEngine.Random.Range(0.2f, 0.7f));
        }
        callback();
        yield return null;
    }


}

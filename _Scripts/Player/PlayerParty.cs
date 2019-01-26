using System.Collections;
using UnityEngine;


public class PlayerParty : MonoBehaviour {
    public GameObject fireworks;


    public void AnimateCompletion() {
        if ( fireworks ) {
            StartCoroutine(PlayFireworks());  
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            AnimateCompletion();
        }

    }

    IEnumerator PlayFireworks() {
        foreach ( ParticleSystem firework in fireworks.GetComponentsInChildren<ParticleSystem>() ) {
            firework.Play();
            firework.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(Random.Range(0.2f, 0.7f));
        }
        yield return null;
    }


}

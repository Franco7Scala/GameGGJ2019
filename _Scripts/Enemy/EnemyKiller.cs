using UnityEngine;


public class EnemyKiller : MonoBehaviour {
    public Patrol patrol;


    public void OnTriggerEnter(Collider other) {
        if ( other.gameObject == Support.sharedObjects.player ) {
            patrol.Kill();
        }
    }


}

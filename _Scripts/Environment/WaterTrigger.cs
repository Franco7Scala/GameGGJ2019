using UnityEngine;


public class WaterTrigger : MonoBehaviour {


    private void OnTriggerEnter(Collider other) {
        if ( other.gameObject == Support.sharedObjects.player ) {
            Support.sharedObjects.player.GetComponent<PlayerMovement>().SetOnWater(true);
        }
    }

    private void OnTriggerExit(Collider other) {
        if ( other.gameObject == Support.sharedObjects.player ) {
            Support.sharedObjects.player.GetComponent<PlayerMovement>().SetOnWater(false);
        }
    }


}

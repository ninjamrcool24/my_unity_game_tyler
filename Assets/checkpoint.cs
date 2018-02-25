using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		playerController player = col.gameObject.GetComponent<playerController> ();
		if (player) {
			player.checkpoint = transform.position;
		}
	}
}
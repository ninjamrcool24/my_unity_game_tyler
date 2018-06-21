using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravity_changer : MonoBehaviour {
	playerController player;
	void Start(){
		player = GameObject.Find ("player").GetComponent<playerController> ();
	}

	void OnTriggerEnter(Collider col) {
//		if (col.gameObject.name == "player") {
			player.rb.useGravity = !player.rb.useGravity;
			Debug.Log ("switch grav");
//		}
		StartCoroutine("gravityCheck");
	}

	IEnumerator gravityCheck(){
		yield return new WaitForSeconds (10);
		if (!player.rb.useGravity) {
			player.rb.useGravity = true;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPad : MonoBehaviour {

	public float boostPadRotation;

	public void Start(){
		boostPadRotation = transform.rotation.z;
	}

	void OnTriggerEnter(Collider col){
		var playerController = col.GetComponent<playerController> ();
		if (playerController != null) {
			StartCoroutine (playerController.SpeedBoost());
		}
	}
}
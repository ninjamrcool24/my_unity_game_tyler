using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPad : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		var playerController = col.GetComponent<playerController> ();
		if (playerController != null) {
			StartCoroutine (playerController.SpeedBoost());
		}
	}
}

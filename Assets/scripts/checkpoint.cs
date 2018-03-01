using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkpoint : MonoBehaviour {
	Text text;

	void Start(){
		text = GameObject.Find ("Text").GetComponent<Text>();
		text.enabled = false;
	}

	void OnTriggerEnter(Collider col){
		playerController player = col.gameObject.GetComponent<playerController> ();
		if (player) {
			player.checkpoint = transform.position;
		}

		text.enabled = true;
		StartCoroutine ("fadeText");
	}

	IEnumerator fadeText(){
		yield return new WaitForSeconds (1.5f);
		text.enabled = false;
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checkpoint : MonoBehaviour {
	Text text;
	bool visited = false;

	void Start(){
		text = GameObject.Find ("Text").GetComponent<Text>();
		text.enabled = false;
	}

	void OnTriggerEnter(Collider col){
		if(!visited){
			playerController player = col.gameObject.GetComponent<playerController> ();
			if (player) {
				player.checkpoint = transform.position;
			}

			text.enabled = true;
			visited = true;
			StartCoroutine ("fadeText");
		}	
	}

	IEnumerator fadeText(){
		yield return new WaitForSeconds (1.5f);
		text.enabled = false;
	}
}
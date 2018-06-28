using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour {
	Text text;
	bool visited = false;

	playerController player;

	void Start(){
		text = GameObject.Find ("Text").GetComponent<Text>();
		player = GameObject.Find ("player").GetComponent<playerController> ();
		text.enabled = false;
	}

	void OnTriggerEnter(Collider col){
		if(!visited){
			playerController player = col.gameObject.GetComponent<playerController> ();
			if (player) {
				player.checkpoints.Add (transform.position);
				player.lives += 1;
                UIController.SetLives();
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
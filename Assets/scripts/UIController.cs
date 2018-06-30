using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {
	public Text livesText;
	public playerController player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("player").GetComponent<playerController> ();
		livesText = GameObject.Find ("lives").GetComponent<Text> ();
		livesText.text = "Lives: " + player.lives;
	}

	public void SetLives(){
		livesText.text = "Lives: " + player.lives;
	}
}
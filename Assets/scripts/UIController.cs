using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public GameObject lives;
	public Text livesText;
	playerController player;
	// Use this for initialization
	void Start () {
		player = GameObject.Find ("player").GetComponent<playerController> ();
		livesText.text = "Lives: " + player.lives;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetLives(){
		livesText.text = "Lives: " + player.lives;
	}
}

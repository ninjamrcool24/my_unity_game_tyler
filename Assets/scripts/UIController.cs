using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

	public GameObject lives;
	public Text livesText;

	// Use this for initialization
	void Start () {

		livesText.text = "Lives: " + playerController.lives;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerController : MonoBehaviour {

    public GameObject player;
    
    private Vector3 offset;
	private float offsetDistance;
	private float yAxis = 0;

	// Use this for initialization
	void Start () {
		offsetDistance = (player.transform.position - transform.position).magnitude;
		offset = player.transform.position - transform.position;
	}

	void Update(){
		if (Input.GetKey (KeyCode.R)) {
			yAxis++;
		}
		if (Input.GetKey (KeyCode.E)) {
			yAxis--;
		}
		Quaternion rotation = Quaternion.Euler(25f, yAxis, 0.0f);

		transform.rotation = rotation; 
		player.transform.rotation = transform.rotation;
		transform.position = player.transform.position + rotation * new Vector3(0.0f, 0.0f, -offsetDistance);
	}
	void LateUpdate(){
		
	}
}

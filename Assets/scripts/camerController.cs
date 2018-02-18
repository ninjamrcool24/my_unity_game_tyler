using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerController : MonoBehaviour {

    public GameObject player;
    
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
    }

	void Update(){
		if (Input.GetKey (KeyCode.R)) {
			transform.RotateAround (player.transform.position, Vector3.up, 50 * Time.deltaTime);

		}
	}
}

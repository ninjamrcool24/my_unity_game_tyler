﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour {
    public float speed;
    public float jumpForce;
	public float speedBoostTime = 2.0f;
	public float maxSpeed = 50;
	public float lives = 10;

    public bool isGrounded = false;
	public bool isBoosting = false;

    public Transform forwardTransform;
	TrailRenderer trail;
    public Rigidbody rb;
	public Checkpoint checkpoint;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
		checkpoint = transform.position;
		Debug.Log (checkpoint);
		trail = GetComponent<TrailRenderer> ();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 MoveHorizontal = Input.GetAxis("Horizontal")*forwardTransform.right ;
        Vector3 MoveVertical   = Input.GetAxis("Vertical")*forwardTransform.forward;

        // Transform cameraTransform = forwardTransform.parent;

        // Debug.Log("Forward Vector: " + forwardTransform.forward + " / Right Vector: " + forwardTransform.right);

        Vector3 movement = (MoveHorizontal+MoveVertical).normalized;

		rb.AddForce (movement * speed);
		rb.velocity = Vector3.ClampMagnitude (rb.velocity, maxSpeed);

        if( Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(Vector3.up * jumpForce);
            isGrounded = false;
        }


		if (lives == 0) {
			checkpoint = checkpoint.lastcheckpoint;

		}

		if (doDie()) {
			die ();
		}
    }

	private bool doDie (){
		return transform.position.y < -10 || Input.GetKeyDown ("k");
	}

	private void die(){
		Debug.Log (checkpoint);
		transform.position = checkpoint.transform.position;
		rb.velocity = Vector3.zero;
		rb.useGravity = true;
		lives + -1;
	}

    void OnCollisionEnter(Collision collide)
    {
        Transform floor = collide.gameObject.transform;

        //Target - Your Position
        if(floor.position.y - transform.position.y < 0.5) {
            isGrounded = true;
        }
    }

	public IEnumerator SpeedBoost(){
		maxSpeed *= 5;
		speed = maxSpeed;
		isBoosting = true;
		rb.AddForce (transform.forward * speed);
		yield return new WaitForSeconds (speedBoostTime);
		maxSpeed /= 5;
		isBoosting = false;
		speed = maxSpeed;
	}
}

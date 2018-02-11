using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    public float speed;
    public float jumpForce;

    public bool isGrounded = false;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float MoveHorizontal = Input.GetAxis("Horizontal");
        float MoveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (MoveHorizontal, 0.0f, MoveVertical);

        rb.AddForce(movement * speed);

        if( Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(Vector3.up * jumpForce);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collide)
    {
        Transform floor = collide.gameObject.transform;

        //Target - Your Position
        if(floor.position.y - transform.position.y < 0.5) {
            isGrounded = true;
        }
    }
}

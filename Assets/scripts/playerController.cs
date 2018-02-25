using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour {

    public float speed;
    public float jumpForce;

    public bool isGrounded = false;

    private Rigidbody rb;
	public Vector3 checkpoint;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
		checkpoint = transform.position;
		Debug.Log (checkpoint);
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
		if (transform.position.y < -10) {
			Debug.Log (checkpoint);
			transform.position = checkpoint;

			//SceneManager.LoadScene("my_unity_project_tyler");
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

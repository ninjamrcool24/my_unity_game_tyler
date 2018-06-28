using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour {
    public float speed;
    public float jumpForce;
	public float speedBoostTime = 2.0f;
	public float maxSpeed = 50;
	public int lives = 10;

    public bool isGrounded = false;
	public bool isBoosting = false;

    public Transform forwardTransform;
	TrailRenderer trail;
    public Rigidbody rb;
	public Checkpoint checkpoint;
	public List<Vector3> checkpoints;
	public UIController uicontroller;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
		trail = GetComponent<TrailRenderer> ();
		checkpoints = new List<Vector3> ();
		uicontroller = GameObject.Find ("Canvas").GetComponent<UIController> ();
		checkpoints.Add (transform.position);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 MoveHorizontal = Input.GetAxis("Horizontal")*forwardTransform.right ;
        Vector3 MoveVertical   = Input.GetAxis("Vertical")*forwardTransform.forward;

        // Transform cameraTransform = forwardTransform.parent;

        // Debug.Log("Forward Vector: " + forwardTransform.forward + " / Right Vector: " + forwardTransform.right);

        Vector3 movement = (MoveHorizontal+MoveVertical).normalized;

		rb.AddForce (movement * speed);
		//rb.velocity = Vector3.ClampMagnitude (rb.velocity, maxSpeed);

        if( Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            rb.AddForce(Vector3.up * jumpForce);
            isGrounded = false;
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
		rb.velocity = Vector3.zero;
		rb.useGravity = true;
		lives -= 1;
        if (lives == 0) {
			if (checkpoints.Count > 1) {
				checkpoints.RemoveAt(checkpoints.Count - 1);
			}
			lives = 10;
		}
		transform.position = checkpoints [checkpoints.Count - 1];
		UIController.SetLives ();
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
		speed = 2000;
		isBoosting = true;
		rb.AddForce (transform.forward * speed);
		yield return new WaitForSeconds (speedBoostTime);
		speed = 25;
		isBoosting = false;
	}
}

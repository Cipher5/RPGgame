using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

	CharacterController cc;
	Animator anim;
	Camera cam;
	public float moveSpeed = 4f;
	string state = "Movement";
	float gravity = 0f;
	float jumpVelocity = 0;
	public float jumpHeight = 16f;

	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController> ();
		anim = GetComponent<Animator> ();
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		if (state == "Movement") {

			Movement ();
			Swing ();
		}
		if (state == "Jump") {
			Jump ();
			Movement ();
		}
	}
	void Movement()
	{
		float x = Input.GetAxisRaw("Horizontal");
		float z = Input.GetAxisRaw ("Vertical");

		Vector3 direction = new Vector3 (x, 0, z).normalized;
		float cameraDirection = cam.transform.localEulerAngles.y;
		direction = Quaternion.AngleAxis (cameraDirection, Vector3.up) * direction;

		Vector3 velocity = direction * moveSpeed * Time.deltaTime;

		if (cc.isGrounded) {
			gravity = 0;
			if (state == "Jump") {
				ChangeState ("Movement");
			}
		} else {
			gravity += 0.25f;
			gravity = Mathf.Clamp (gravity, 1f, 20f);
		}

		if (Input.GetKeyDown (KeyCode.Space) && cc.isGrounded) {
			jumpVelocity = jumpHeight;
			ChangeState ("Jump");

		}

		Vector3 gravityVector = -Vector3.up * gravity * Time.deltaTime;
		Vector3 jumpVector = Vector3.up * jumpVelocity * Time.deltaTime;

		float percentSpeed = velocity.magnitude / (moveSpeed * Time.deltaTime);
		anim.SetFloat ("movePercent", percentSpeed);

		cc.Move (velocity + gravityVector + jumpVector);
		if (velocity.magnitude > 0) {
			float yAngle = Mathf.Atan2 (direction.x, direction.z) * Mathf.Rad2Deg;

			transform.localEulerAngles = new Vector3 (0, yAngle, 0);
		}
	}
	void Jump() {
		if (jumpVelocity < 0) { return; }
		jumpVelocity -= 1.25f;
	}
	void ChangeState(string stateName){
		state = stateName;
		anim.SetTrigger (stateName);

	}
	void ReturnToMovement()
	{
		ChangeState ("Movement");
	}


	void Swing()
	{
		if (Input.GetMouseButtonDown (0)) {
			ChangeState ("Swing");
		}
	}
}

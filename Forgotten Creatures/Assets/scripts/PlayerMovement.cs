using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//i added this just to make a change

public class PlayerMovement : MonoBehaviour {

	Rigidbody rg;
	public float MoveSpeed;
	public float JumpForce;
	public float rotSpeed;
	bool isGrounded;

	void Start () {
		rg = GetComponent<Rigidbody> ();
		isGrounded = true;
	}
	
	void Update () {
		Walking ();
	}

	void Walking(){
		Quaternion desiredRot;
		if (Input.GetKey (KeyCode.D)) {
			rg.velocity = new Vector3(MoveSpeed, rg.velocity.y, 0);
			desiredRot = Quaternion.Euler (0, 90, 0);
			transform.rotation = Quaternion.Lerp (transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
		}

		if (Input.GetKeyUp(KeyCode.D)) {
			rg.velocity = new Vector3(0, rg.velocity.y, 0);
			desiredRot = Quaternion.Euler (0, 90, 0);
			transform.rotation = desiredRot;
		}

		if (Input.GetKey (KeyCode.A)) {
			rg.velocity = new Vector3(-MoveSpeed, rg.velocity.y, 0);
			desiredRot = Quaternion.Euler (0, -90, 0);
			transform.rotation = Quaternion.Lerp (transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
		}

		if (Input.GetKeyUp(KeyCode.A)) {
			rg.velocity = new Vector3(0, rg.velocity.y, 0);
			desiredRot = Quaternion.Euler (0, -90, 0);
			transform.rotation = desiredRot;
		}

		if (isGrounded && Input.GetKeyDown (KeyCode.Space)) {
			rg.AddForce (Vector3.up * JumpForce);
			isGrounded = false;
		}
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.CompareTag ("ground")) {
			isGrounded = true;
		}
	}
}

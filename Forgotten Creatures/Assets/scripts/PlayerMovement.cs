using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
		if (isGrounded && Input.GetKey (KeyCode.D)) {
			rg.velocity = Vector3.right * MoveSpeed * Time.deltaTime;
			desiredRot = Quaternion.Euler (0, 90, 0);
			transform.rotation = Quaternion.Lerp (transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
		}

		if (isGrounded && Input.GetKey (KeyCode.A)) {
			rg.velocity = -Vector3.right * MoveSpeed * Time.deltaTime;
			desiredRot = Quaternion.Euler (0, -90, 0);
			transform.rotation = Quaternion.Lerp (transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
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

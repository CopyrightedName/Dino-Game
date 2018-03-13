using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//i added this just to make a change

public class PlayerMovement : MonoBehaviour {

	Rigidbody rg;
	public float MoveSpeed;
	public float sprintSpeed;
	public float JumpForce;
	public float rotSpeed;
	bool isGrounded;
	bool isWalking;

	[Header("health")]


	[Header("sprint")]

	bool canIncrease = false;
	public float stamina;
	public float maxStamina;
	public float staminaToTake;

	public Animator anim;

	void Start () {
		stamina = maxStamina;
		rg = GetComponent<Rigidbody> ();
		isGrounded = true;
	}
	
	void Update () {
		Walking ();

		if (isGrounded) {
			if (rg.IsSleeping ()) {
				anim.SetBool ("walking", false);
			} else {
				anim.SetBool ("walking", true);
			}		
		} else {
			anim.SetBool ("walking", false);
		}

		if (canIncrease) {
			stamina = stamina + 0.5f;
		}
	}

	void Walking(){

		stamina = Mathf.Clamp (stamina, 0, maxStamina);

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

		if (stamina >= 0 && Input.GetKey (KeyCode.LeftShift)) {
			stamina = stamina - staminaToTake;
			MoveSpeed = sprintSpeed;
			canIncrease = false;
		}

		if (Input.GetKeyUp(KeyCode.LeftShift)) {
			MoveSpeed = 10f;
			StartCoroutine (increaseStamina ());
		}

		if (stamina <= 0) {
			MoveSpeed = 10f;
		}

		if (stamina >= maxStamina) {
			canIncrease = false;
		}
	}

	IEnumerator increaseStamina(){
		yield return new WaitForSeconds (3);
		canIncrease = true;
	}

	void OnCollisionEnter(Collision other){
		if (other.gameObject.CompareTag ("ground")) {
			isGrounded = true;
		}
	}
}

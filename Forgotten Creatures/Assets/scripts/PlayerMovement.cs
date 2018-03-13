using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour {

	Rigidbody rg;
	public Animator anim;
	public GameObject enemy;
	public Transform EnemyTarget;

	[Header("walking")]
	public float MoveSpeed;
	public float sprintSpeed;
	public float JumpForce;
	public float rotSpeed;

	[Header("health")]

	public float maxHP;
	public float HP;
	public float HPtoTake;

	[Header("sprint")]

	public float stamina;
	public float maxStamina;
	public float staminaToTake;

	bool canIncrease = false;
	bool isGrounded;
	bool isWalking;
	bool canMove = true;

	void Start () {
		stamina = maxStamina;
		rg = GetComponent<Rigidbody> ();
		isGrounded = true;
		HP = maxHP;
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

		if (HP <= 0) {
			Die ();
		}
	}

	void Walking(){
		if (canMove) {
			stamina = Mathf.Clamp (stamina, 0, maxStamina);

			Quaternion desiredRot;

			if (Input.GetKey (KeyCode.D)) {
				rg.velocity = new Vector3 (MoveSpeed, rg.velocity.y, 0);
				desiredRot = Quaternion.Euler (0, 90, 0);
				transform.rotation = Quaternion.Lerp (transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
			}

			if (Input.GetKeyUp (KeyCode.D)) {
				rg.velocity = new Vector3 (0, rg.velocity.y, 0);
				desiredRot = Quaternion.Euler (0, 90, 0);
				transform.rotation = desiredRot;
			}

			if (Input.GetKey (KeyCode.A)) {
				rg.velocity = new Vector3 (-MoveSpeed, rg.velocity.y, 0);
				desiredRot = Quaternion.Euler (0, -90, 0);
				transform.rotation = Quaternion.Lerp (transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
			}

			if (Input.GetKeyUp (KeyCode.A)) {
				rg.velocity = new Vector3 (0, rg.velocity.y, 0);
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

			if (Input.GetKeyUp (KeyCode.LeftShift)) {
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

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("triceratops")) {
			HP = HP - 50;
		}
		if (other.gameObject.CompareTag ("trex")) {
			HP = HP - 100;
		}
		if (other.gameObject.CompareTag ("compy")) {
			HP = HP - 10;
		}
	}

	void Die(){
		rg.velocity = Vector3.zero;
		anim.SetBool ("walking", false);
		canMove = false;
		transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.y + -90, transform.rotation.z + 90), rotSpeed);
		enemy.GetComponent<EnemyAI> ().agent.SetDestination (EnemyTarget.position);
	}
}

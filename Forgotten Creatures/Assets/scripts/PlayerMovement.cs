using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//awdawda

public class PlayerMovement : MonoBehaviour {

	public Rigidbody rg;
	public Animator anim;
	public GameObject enemy;
	public Transform EnemyTarget;
	public RectTransform rect;

	[Header("walking")]
	public float MoveSpeed;
	public float sprintSpeed;
	public float JumpForce;
	public float rotSpeed;

	[Header("health")]

	public float maxHP;
	float HP;

	[Header("sprint")]

	float stamina;
	public float maxStamina;
	public float staminaToTake;

	[Header("colors")]
	public Color green;
	public Color yellow;
	public Color orange;
	public Color red;
	public Color darkRed;

	bool canIncrease = false;
	bool isGrounded;
	public bool isWalking;
	public bool canMove = true;
	public bool isDead;

	void Start () {
		stamina = maxStamina;
		rg = GetComponent<Rigidbody> ();
		isGrounded = true;
		HP = maxHP;
		anim.SetBool ("walking", false);

	}
	
	void Update () {
		Walking ();
		HPbar ();

		if (!isDead) {
			if (isGrounded) {
				anim.SetBool ("jumping", false);
				if (!isWalking) {
					anim.SetBool ("walking", false);
				} else {
					anim.SetBool ("walking", true);
				}		
			} else {
				anim.SetBool ("walking", false);
				anim.SetBool ("jumping", true);
			}

			if (canIncrease) {
				stamina = stamina + 0.5f;
			}

			if (HP <= 0) {
				Die ();
			}
		}
	}

	void Walking(){
		if (canMove && !isDead) {
			stamina = Mathf.Clamp (stamina, 0, maxStamina);

			if (HP < 0) {
				HP = 0;
			}

			Quaternion desiredRot;

			if (Input.GetKey (KeyCode.D)) {
				rg.velocity = new Vector3 (MoveSpeed, rg.velocity.y, 0);
				desiredRot = Quaternion.Euler (0, 90, 0);
				transform.rotation = Quaternion.Lerp (transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
				isWalking = true;
			}

			if (Input.GetKeyUp (KeyCode.D)) {
				rg.velocity = new Vector3 (0, rg.velocity.y, 0);
				desiredRot = Quaternion.Euler (0, 90, 0);
				transform.rotation = desiredRot;
				isWalking = false;

			}

			if (Input.GetKey (KeyCode.A)) {
				rg.velocity = new Vector3 (-MoveSpeed, rg.velocity.y, 0);
				desiredRot = Quaternion.Euler (0, -90, 0);
				transform.rotation = Quaternion.Lerp (transform.rotation, desiredRot, rotSpeed * Time.deltaTime);
				isWalking = true;

			}

			if (Input.GetKeyUp (KeyCode.A)) {
				rg.velocity = new Vector3 (0, rg.velocity.y, 0);
				desiredRot = Quaternion.Euler (0, -90, 0);
				transform.rotation = desiredRot;
				isWalking = false;

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
				MoveSpeed = 15;
				StartCoroutine (increaseStamina ());
			}

			if (stamina <= 0) {
				MoveSpeed = 15;
			}

			if (stamina >= maxStamina) {
				canIncrease = false;
			}
		}
	}

	void HPbar(){
		if (HP == 100) {
			rect.GetComponent<RawImage> ().color = green;
		}

		if (HP <= 75) {
			rect.GetComponent<RawImage> ().color = yellow;
		}

		if (HP <= 50) {
			rect.GetComponent<RawImage> ().color = orange;
		}

		if (HP <= 25) {
			rect.GetComponent<RawImage> ().color = red;
		}

		if (HP <= 10) {
			rect.GetComponent<RawImage> ().color = darkRed;
		}

		rect.sizeDelta =  Vector2.Lerp (rect.sizeDelta ,new Vector2(HP, rect.sizeDelta.y), 0.1f);
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
			HP = HP - 30;
		}
		if (other.gameObject.CompareTag ("trex")) {
			HP = HP - 100;
		}
		if (other.gameObject.CompareTag ("compy")) {
			HP = HP - 5;
		}
	}

	void Die(){
		if (!isDead) {
			isDead = true;
			anim.SetBool ("walking", false);
			canMove = false;
			transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler (transform.rotation.x, transform.rotation.y + -90, transform.rotation.z + 90), rotSpeed);
			enemy.GetComponent<EnemyAI> ().agent.SetDestination (EnemyTarget.position);
		}
	}
}

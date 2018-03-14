using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class EnemyAI : MonoBehaviour {

	public NavMeshAgent agent;
	public float moveSpeed;
	public Transform target;
	public GameObject coll;
	public Animator anim;
	public RectTransform rect;

	[Header("health")]

	public float maxHP;
	public float HP;

	[Header("colors")]
	public Color green;
	public Color yellow;
	public Color orange;
	public Color red;
	public Color darkRed;


	void Start () {
		anim = GetComponent<Animator>();
		HP = maxHP;
		agent = GetComponent<NavMeshAgent> ();
	}
	
	void Update () {

		HPbar ();
		

		if (agent.hasPath == true) {
			anim.SetBool ("walking", true);
		} else {
			anim.SetBool ("walking", false);
		}

		if (HP <= 0) {
			StartCoroutine (Die ());
		}

		if (agent.hasPath == true) {
			if (agent.remainingDistance < agent.stoppingDistance) {
				agent.SetDestination (target.position);
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			agent.SetDestination (target.position);
		}
		if (other.gameObject.CompareTag ("bullet")) {
			HP = HP - 25;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			StartCoroutine (waitToStop());
		}
	}

	void HPbar(){
		if (HP == 100) {
			rect.GetComponent<Image> ().color = green;
		}

		if (HP <= 75) {
			rect.GetComponent<Image> ().color = yellow;
		}

		if (HP <= 50) {
			rect.GetComponent<Image> ().color = orange;
		}

		if (HP <= 25) {
			rect.GetComponent<Image> ().color = red;
		}

		if (HP <= 10) {
			rect.GetComponent<Image> ().color = darkRed;
		}

		rect.sizeDelta =  Vector2.Lerp (rect.sizeDelta ,new Vector2(HP / 25, rect.sizeDelta.y), 0.05f);
	}

	IEnumerator waitToStop(){
		agent.SetDestination (target.position);
		yield return new WaitForSeconds (5);
		agent.ResetPath ();
	}

	IEnumerator Die(){
		agent.enabled = false;
		Destroy (coll);
		transform.rotation = Quaternion.Lerp (transform.rotation, Quaternion.Euler(transform.rotation.x, transform.rotation.y + 90, transform.rotation.z + 90), 0.5f);
		yield return new WaitForSeconds (4);
		Destroy (gameObject);
	}
}

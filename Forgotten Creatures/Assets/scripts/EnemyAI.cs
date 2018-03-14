using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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


	void Start () {
		anim = GetComponent<Animator>();
		HP = maxHP;
		agent = GetComponent<NavMeshAgent> ();
	}
	
	void Update () {
		rect.sizeDelta =  Vector2.Lerp (rect.sizeDelta ,new Vector2(HP / 25, rect.sizeDelta.y), 0.05f);

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

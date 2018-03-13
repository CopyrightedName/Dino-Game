﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {

	NavMeshAgent agent;
	public float moveSpeed;
	public Transform target;

	void Start () {
		agent = GetComponent<NavMeshAgent> ();
	}
	
	void Update () {
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
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			StartCoroutine (waitToStop());
		}
	}

	IEnumerator waitToStop(){
		agent.SetDestination (target.position);
		yield return new WaitForSeconds (10);
		agent.ResetPath ();
	}
}

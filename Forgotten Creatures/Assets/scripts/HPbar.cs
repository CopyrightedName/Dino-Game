using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPbar : MonoBehaviour {

	Transform target;
	EnemyAI AI;

	void Start () {
		target = FindObjectOfType<EnemyAI> ().transform;
		AI = FindObjectOfType<EnemyAI> ();
	}
	
	void LateUpdate () {
		if (AI.isDead == false) {
			transform.position = target.transform.position;
		}
	}
}

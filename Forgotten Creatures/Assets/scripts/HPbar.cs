using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPbar : MonoBehaviour {

	public Transform target;
	EnemyAI AI;

	void Start () {
		AI = FindObjectOfType<EnemyAI> ();
	}
	
	void LateUpdate () {
		if (AI.isDead == false) {
			transform.position = target.transform.position;
		}
	}
}

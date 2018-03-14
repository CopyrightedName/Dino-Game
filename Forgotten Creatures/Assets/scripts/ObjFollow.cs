using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjFollow : MonoBehaviour {

	Transform target;

	void Start () {
	}
	
	void LateUpdate () {
		target = FindObjectOfType<PlayerMovement> ().transform;

		this.transform.position = target.transform.position;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPbar : MonoBehaviour {

	public Transform target;

	void Start () {
	}
	
	void LateUpdate () {
		transform.position = target.transform.position;
	}
}

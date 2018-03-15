using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Insatnce : MonoBehaviour {

	public GameObject prefab;

	void Start () {
		if (FindObjectsOfType<DontDes>().Length == 0) {
			GameObject instantiated = Instantiate (prefab, transform.position, transform.rotation);
		} else {
			return;
		}
	}
	
	void Update () {
		
	}
}

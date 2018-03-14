using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateScript : MonoBehaviour {

	public GameObject lvlPrefab;

	void Start () {
		Instantiate (lvlPrefab, transform.position, transform.rotation);
	}
	
	void Update () {
		
	}
}

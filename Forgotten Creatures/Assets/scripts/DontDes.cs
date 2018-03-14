using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDes : MonoBehaviour {

	public GameObject lvlPrefab;

	void Start () {
	}

	void Awake(){
		DontDestroyOnLoad (this);
	}
	
	void Update () {
		Instantiate (lvlPrefab, transform.position, transform.rotation);
	}
}

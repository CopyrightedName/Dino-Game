using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour {

	Map map;

	bool hasLoaded = false;

	void Start () {
		map = FindObjectOfType<Map> ();
	}
	
	void Update () {

	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("finish")) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		}
	}
}

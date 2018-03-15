using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour {

	Map map;

	bool hasLoaded = false;

	void Start () {
	}
	
	void Update () {

	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("finish")) {
			FindObjectOfType<Map> ().completed [FindObjectOfType<Map> ().completedCount] = true;
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
			FindObjectOfType<Map> ().mapObj.SetActive (false);
		}
	}
}

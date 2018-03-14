using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour {

	Map map;

	void Start () {
		map = FindObjectOfType<Map> ();
	}
	
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("finish")) {
			StartCoroutine (wait ());
		}

	}

	IEnumerator wait(){
		gameObject.GetComponent<SphereCollider> ().enabled = false;
		yield return new WaitForSeconds (0.5f);
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
		map.completed[0] = true;
		gameObject.GetComponent<SphereCollider> ().enabled = true;
	}
}

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
		if (other.gameObject.CompareTag ("Finish1")) {
			Destroy (gameObject);
			SceneManager.LoadScene ("Level2", LoadSceneMode.Single);
			map.completed [0] = true;
		}

		if (other.gameObject.CompareTag ("Finish2")) {
			Destroy (gameObject);
			SceneManager.LoadScene ("Level3", LoadSceneMode.Single);
			map.completed [1] = true;
		}

		if (other.gameObject.CompareTag ("Finish3")) {
			Destroy (gameObject);
			SceneManager.LoadScene ("Level4", LoadSceneMode.Single);
			map.completed [2] = true;
		}

		if (other.gameObject.CompareTag ("Finish4")) {
			SceneManager.LoadScene ("Level5", LoadSceneMode.Single);
			map.completed [3] = true;
		}

		if (other.gameObject.CompareTag ("Finish5")) {
			SceneManager.LoadScene ("Level6", LoadSceneMode.Single);
			map.completed [4] = true;
		}

		if (other.gameObject.CompareTag ("Finish6")) {
			SceneManager.LoadScene ("Level7", LoadSceneMode.Single);
			map.completed [5] = true;
		}

		if (other.gameObject.CompareTag ("Finish7")) {
			SceneManager.LoadScene ("Level8", LoadSceneMode.Single);
			map.completed [6] = true;
		}

		if (other.gameObject.CompareTag ("Finish8")) {
			SceneManager.LoadScene ("Level9", LoadSceneMode.Single);
			map.completed [7] = true;
		}

		if (other.gameObject.CompareTag ("Finish9")) {
			SceneManager.LoadScene ("Level10", LoadSceneMode.Single);
			map.completed [8] = true;
		}


		if (other.gameObject.CompareTag ("Finish10")) {
			SceneManager.LoadScene ("Level10", LoadSceneMode.Single);
			map.completed [9] = true;
		}
	}
}

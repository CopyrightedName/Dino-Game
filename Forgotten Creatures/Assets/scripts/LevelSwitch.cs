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
			SceneManager.LoadScene ("Level2", LoadSceneMode.Additive);
			map.completed [0] = true;
		}

		if (other.gameObject.CompareTag ("Finish2")) {
			SceneManager.LoadScene ("Level3", LoadSceneMode.Additive);
			map.completed [1] = true;
		}

		if (other.gameObject.CompareTag ("Finish3")) {
			SceneManager.LoadScene ("Level4", LoadSceneMode.Additive);
			map.completed [2] = true;
		}

		if (other.gameObject.CompareTag ("Finish4")) {
			SceneManager.LoadScene ("Level5", LoadSceneMode.Additive);
			map.completed [3] = true;
		}

		if (other.gameObject.CompareTag ("Finish5")) {
			SceneManager.LoadScene ("Level6", LoadSceneMode.Additive);
			map.completed [4] = true;
		}

		if (other.gameObject.CompareTag ("Finish6")) {
			SceneManager.LoadScene ("Level7", LoadSceneMode.Additive);
			map.completed [5] = true;
		}

		if (other.gameObject.CompareTag ("Finish7")) {
			SceneManager.LoadScene ("Level8", LoadSceneMode.Additive);
			map.completed [6] = true;
		}

		if (other.gameObject.CompareTag ("Finish8")) {
			SceneManager.LoadScene ("Level9", LoadSceneMode.Additive);
			map.completed [7] = true;
		}

		if (other.gameObject.CompareTag ("Finish9")) {
			SceneManager.LoadScene ("Level10", LoadSceneMode.Additive);
			map.completed [8] = true;
		}


		if (other.gameObject.CompareTag ("Finish10")) {
			SceneManager.LoadScene ("Level10", LoadSceneMode.Additive);
			map.completed [9] = true;
		}
	}
}

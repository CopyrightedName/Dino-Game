using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class NodeSceneSwitch : MonoBehaviour {

	Map map;

	public int nodeNum;
	public int sceneNum;

	void Start () {
		map = FindObjectOfType<Map> ();
	}
	
	void Update () {
		
	}

	public void Click(){
		if (map.unlocked[nodeNum] == true) {
			SceneManager.LoadScene (sceneNum, LoadSceneMode.Single);
			map.mapObj.SetActive (false);
			map.isOpen = false;
		}
	}
}

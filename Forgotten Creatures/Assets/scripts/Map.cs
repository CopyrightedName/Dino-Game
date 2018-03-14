using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour {

	public GameObject mapObj;
	public GameObject[] nodes;

	public bool[] completed;
	public bool[] unlocked;

	bool isOpen = false;

	void Start () {
		unlocked [0] = true;
		unlocked [1] = false;
		unlocked [2] = false;
		unlocked [3] = false;
		unlocked [4] = false;
		unlocked [5] = false;
		unlocked [6] = false;
		unlocked [7] = false;
		unlocked [8] = false;
		unlocked [9] = false;

		mapObj.SetActive (false);
	}
	
	void Update () {
		OpenMap ();
		Nodes ();
	}

	void OpenMap(){
		
		if (!isOpen && Input.GetKeyDown (KeyCode.Tab)) {
			mapObj.SetActive (true);
			isOpen = true;
		} else if (isOpen && Input.GetKeyDown (KeyCode.Tab)) {
			mapObj.SetActive (false);
			isOpen = false;
		}

	}

	void Nodes(){
		if (completed [0] == true) {
			unlocked [1] = true;
			nodes [0].gameObject.GetComponent<Image> ().color = Color.green;
		}

		if (completed [1] == true) {
			unlocked [2] = true;
			nodes [1].gameObject.GetComponent<Image> ().color = Color.green;
		}

		if (completed [2] == true) {
			unlocked [3] = true;
			nodes [2].gameObject.GetComponent<Image> ().color = Color.green;
		}

		if (completed [3] == true) {
			unlocked [4] = true;
			nodes [3].gameObject.GetComponent<Image> ().color = Color.green;
		}

		if (completed [4] == true) {
			unlocked [5] = true;
			nodes [4].gameObject.GetComponent<Image> ().color = Color.green;
		}

		if (completed [5] == true) {
			unlocked [6] = true;
			nodes [5].gameObject.GetComponent<Image> ().color = Color.green;
		}

		if (completed [6] == true) {
			unlocked [7] = true;
			nodes [6].gameObject.GetComponent<Image> ().color = Color.green;
		}

		if (completed [7] == true) {
			unlocked [8] = true;
			nodes [7].gameObject.GetComponent<Image> ().color = Color.green;
		}

		if (completed [8] == true) {
			unlocked [9] = true;
			nodes [8].gameObject.GetComponent<Image> ().color = Color.green;
		}

		if (completed [9] == true) {
			nodes [9].gameObject.GetComponent<Image> ().color = Color.green;
		}
	}
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Map : MonoBehaviour {

	public GameObject mapObj;
	public GameObject[] nodes;

	public bool[] completed;
	public bool[] unlocked;

	public bool isOpen = false;

	public int completedCount;

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

		if (isOpen) {
			FindObjectOfType<PlayerMovement> ().canMove = false;
			FindObjectOfType<PlayerMovement> ().rg.velocity = Vector3.zero;
			FindObjectOfType<PlayerMovement> ().isWalking = false;
			FindObjectOfType<PlayerShoot> ().canShoot = false;
		} else if (!isOpen) {
			FindObjectOfType<PlayerMovement> ().canMove = true;
			FindObjectOfType<PlayerShoot> ().canShoot = true;
		}
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
			completedCount = 1;
			unlocked [1] = true;
			nodes [0].gameObject.GetComponent<Image> ().color = Color.green;
			nodes [1].gameObject.GetComponent<Image> ().color = Color.blue;
		}

		if (completed [1] == true) {
			completedCount = 2;
			unlocked [2] = true;
			nodes [1].gameObject.GetComponent<Image> ().color = Color.green;
			nodes [2].gameObject.GetComponent<Image> ().color = Color.blue;
		}

		if (completed [2] == true) {
			completedCount = 3;
			unlocked [3] = true;
			nodes [2].gameObject.GetComponent<Image> ().color = Color.green;
			nodes [3].gameObject.GetComponent<Image> ().color = Color.blue;
		}

		if (completed [3] == true) {
			completedCount = 4;
			unlocked [4] = true;
			nodes [3].gameObject.GetComponent<Image> ().color = Color.green;
			nodes [4].gameObject.GetComponent<Image> ().color = Color.blue;
		}

		if (completed [4] == true) {
			completedCount = 5;
			unlocked [5] = true;
			nodes [4].gameObject.GetComponent<Image> ().color = Color.green;
			nodes [5].gameObject.GetComponent<Image> ().color = Color.blue;
		}

		if (completed [5] == true) {
			completedCount = 6;
			unlocked [6] = true;
			nodes [5].gameObject.GetComponent<Image> ().color = Color.green;
			nodes [6].gameObject.GetComponent<Image> ().color = Color.blue;
		}

		if (completed [6] == true) {
			completedCount = 7;
			unlocked [7] = true;
			nodes [6].gameObject.GetComponent<Image> ().color = Color.green;
			nodes [7].gameObject.GetComponent<Image> ().color = Color.blue;
		}

		if (completed [7] == true) {
			completedCount = 8;
			unlocked [8] = true;
			nodes [7].gameObject.GetComponent<Image> ().color = Color.green;
			nodes [8].gameObject.GetComponent<Image> ().color = Color.blue;
		}

		if (completed [8] == true) {
			completedCount = 9;
			unlocked [9] = true;
			nodes [8].gameObject.GetComponent<Image> ().color = Color.green;
			nodes [9].gameObject.GetComponent<Image> ().color = Color.blue;
		}

		if (completed [9] == true) {
			completedCount = 10;
			nodes [9].gameObject.GetComponent<Image> ().color = Color.green;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DontDes : MonoBehaviour {

	public GameObject lvlObj;

	void Start(){
		DontDestroyOnLoad (this);
	}
}

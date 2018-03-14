using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

	public GameObject bullet;
	public Transform pos1;
	public Transform pos2;

	void Start () {
		
	}
	
	void Update () {
		Shoot ();
	}

	void Shoot(){
		if (Input.GetMouseButtonDown (0)) {
			GameObject bulletInstance1 = Instantiate (bullet, pos1.position, pos1.transform.rotation);
			GameObject bulletInstance2 = Instantiate (bullet, pos2.position, pos2.transform.rotation);
		}
	}
}

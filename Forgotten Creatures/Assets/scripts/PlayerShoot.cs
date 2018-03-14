using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {

	public GameObject bullet;
	public Transform pos1;
	public Transform pos2;

	PlayerMovement playerM;

	void Start () {
		playerM = FindObjectOfType<PlayerMovement> ();
	}
	
	void Update () {
		if (playerM.isDead == false) {
			Shoot ();
		}
	}

	void Shoot(){
		if (Input.GetMouseButtonDown (0)) {
			GameObject bulletInstance1 = Instantiate (bullet, pos1.position, pos1.transform.rotation);
			GameObject bulletInstance2 = Instantiate (bullet, pos2.position, pos2.transform.rotation);
			StartCoroutine (destroyAfterSeconds (bulletInstance1, bulletInstance2));
		}
	}

	IEnumerator destroyAfterSeconds(GameObject bul1, GameObject bul2){
		yield return new WaitForSeconds (2);
		Destroy (bul1);
		Destroy (bul2);
	}
}

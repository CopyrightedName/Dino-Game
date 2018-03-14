using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour {

	public GameObject bullet;
	public Transform pos1;
	public Transform pos2;
	public Text bulletText;

	public int bullets = 64;

	PlayerMovement playerM;
	bool canShoot = true;

	void Start () {
		playerM = FindObjectOfType<PlayerMovement> ();
	}
	
	void Update () {
		bulletText.text = bullets.ToString ();

		if (playerM.isDead == false) {
			Shoot ();
		}
	}

	void Shoot(){
		if (bullets > 0 && canShoot && Input.GetMouseButtonDown (0)) {
			bullets = bullets - 1;
			GameObject bulletInstance1 = Instantiate (bullet, pos1.position, pos1.transform.rotation);
			GameObject bulletInstance2 = Instantiate (bullet, pos2.position, pos2.transform.rotation);
			StartCoroutine (destroyAfterSeconds (bulletInstance1, bulletInstance2));
			StartCoroutine (shootDelay ());
		}
	}

	IEnumerator destroyAfterSeconds(GameObject bul1, GameObject bul2){
		yield return new WaitForSeconds (2);
		Destroy (bul1);
		Destroy (bul2);
	}

	IEnumerator shootDelay(){
		canShoot = false;
		yield return new WaitForSeconds (0.5f);
		canShoot = true;
	}
}

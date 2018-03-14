using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	Rigidbody rg;
	public float bulletForce;

	void Start () {
		rg = GetComponent<Rigidbody> ();
		rg.AddForce (transform.forward * bulletForce);
	}
	
	void Update () {
	}
}

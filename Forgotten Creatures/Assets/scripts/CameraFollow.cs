using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public Transform cam;

	public float camDisMax = 25f;
	public float camDisMin = 1f;
	float camDis;
	public float scrollSpeed = 2f;

	void Start () {
		camDis = cam.position.z;
	}
	
	void LateUpdate () {
		Scroll();
		transform.position = target.transform.position;
	}

	void Scroll(){
		camDis += Input.GetAxis ("Mouse ScrollWheel") * scrollSpeed;
		camDis = Mathf.Clamp (camDis, camDisMin, camDisMax);

		cam.transform.position = new Vector3 (cam.position.x,cam.position.y,camDis);
	}
}

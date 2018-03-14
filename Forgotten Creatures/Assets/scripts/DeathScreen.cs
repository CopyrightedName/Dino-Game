using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour {

	PlayerMovement m_player;
	public GameObject deathScreen;
	public GameObject deathScreen1;
	public GameObject restartButton;

	void Start () {
		restartButton.SetActive (false);
		m_player = FindObjectOfType<PlayerMovement> ();
	}
	
	void Update () {
		if (m_player.isDead == true) {
			StartCoroutine (ded(0.5f, deathScreen.GetComponent<Text>(), deathScreen1.GetComponent<Text>()));
		}
	}

	IEnumerator ded(float t, Text i, Text i1){
		yield return new WaitForSeconds (1);
		i.color = new Color (i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
		i1.color = new Color (i1.color.r, i1.color.g, i1.color.b, i1.color.a + (Time.deltaTime / t));
		restartButton.SetActive (true);
	}

	public void Restart(){
		SceneManager.LoadScene ("World 1", LoadSceneMode.Single);
	}
}

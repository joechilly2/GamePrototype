using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour {

	//Handles player health, is put onto player object
	//Only 1 of these should exist at any time.

	public int playerMaxHealth;
	public int playerCurrentHealth;

	private bool startDeathTimer = false;
	private float transitionTime = 3f;
	private float transitionTimer;

	// Use this for initialization
	void Start () {
		playerCurrentHealth = playerMaxHealth;
		transitionTimer = transitionTime;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerCurrentHealth <= 0) {
			playerCurrentHealth = 0;
			//gameObject.SetActive (false);
			startDeathTimer = true;
			if (startDeathTimer) {
//				transitionTimer -= Time.deltaTime;
//				if(transitionTimer <= transitionTime){
				//GameObject.Find ("Player").SetActive (true);
				SceneManager.LoadScene ("DeathScreen");
//				}
			}
		}

		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			if (GameObject.FindGameObjectWithTag ("GlobalValueHolder").GetComponent<GlobalValueHolder> ().GetHealthPotions() >= 1) {
				GameObject.FindGameObjectWithTag ("GlobalValueHolder").GetComponent<GlobalValueHolder> ().UseHealthPotion ();
				playerCurrentHealth += 50;
				if (playerCurrentHealth > playerMaxHealth) {
					playerCurrentHealth = playerMaxHealth;
				}
			}
		}

	}


	public void HurtPlayer(int damageToGive){
		playerCurrentHealth -= damageToGive;
	}

	public void SetMaxHealth(){
		playerCurrentHealth = playerMaxHealth;
	}
}

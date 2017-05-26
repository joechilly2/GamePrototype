using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour {

	//Handles player health, is put onto player object
	//Only 1 of these should exist at any time.

	public int playerMaxHealth;
	public int playerCurrentHealth;

	// Use this for initialization
	void Start () {
		playerCurrentHealth = playerMaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (playerCurrentHealth <= 0) {
			gameObject.SetActive (false);
		}

		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			GameObject.FindGameObjectWithTag ("GlobalValueHolder").GetComponent<GlobalValueHolder> ().UseHealthPotion ();
			playerCurrentHealth += 50;
			if (playerCurrentHealth > playerMaxHealth) {
				playerCurrentHealth = playerMaxHealth;
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

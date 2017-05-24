using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

	//Script that is used to damage players.
	//Is put onto enemies, not players

	public int damageToGive;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "Player") {
			if (other.gameObject.GetComponent<PlayerController> ().invulnurable == false) {
				other.gameObject.GetComponent<PlayerHealthManager> ().HurtPlayer (damageToGive);
				other.gameObject.GetComponent<PlayerController> ().invulnurable = true;
			}
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.name == "Player") {
			if (other.gameObject.GetComponent<PlayerController> ().invulnurable == false) {
				other.gameObject.GetComponent<PlayerHealthManager> ().HurtPlayer (damageToGive);
				other.gameObject.GetComponent<PlayerController> ().invulnurable = true;
			}
		}
	}
}

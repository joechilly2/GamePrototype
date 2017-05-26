using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreenCleanup : MonoBehaviour {

	private float invulntime = 3f;
	private float invulntimer = 3f;



	// Use this for initialization
	void Start () {
		GameObject.Find ("Player").GetComponent<PlayerHealthManager>().playerCurrentHealth = 100;
		GameObject.Find ("Real Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
			invulntimer -= Time.deltaTime;
			if (invulntimer <= 0) {
				Application.Quit();
			}
		}
}

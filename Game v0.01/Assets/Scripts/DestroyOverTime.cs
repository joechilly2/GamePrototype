using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour {

	//Simple script that turns objects into time bombs
	//Used currently for: particles, damage numbers

	public float timeToDestroy;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timeToDestroy -= Time.deltaTime;

		if (timeToDestroy <= 0) {
			Destroy (gameObject);
		}
	}
}

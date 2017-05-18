using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractArea : MonoBehaviour {

	//UNUSED. If this is causing any errors please delete it
	//Replaced with dialogue manager script

	public bool isActive;

	public string currentInteraction;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("area triggered");
		if (other.isActiveAndEnabled) {
			currentInteraction = other.GetComponent<InteractAreaProperties> ().GetText ();
			this.GetComponentInParent<PlayerInteractionAreas> ().SetText (currentInteraction);
			this.GetComponentInParent<PlayerInteractionAreas>().setAreaTrue();
		}
	}


}

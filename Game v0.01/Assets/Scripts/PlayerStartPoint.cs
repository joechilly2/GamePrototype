using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour {

	//Similar to LoadNewArea script
	//Finds the start location for the player and moves them there are the start of the game
	//Is attached to the gameobject that is the spawn location for the player

	private PlayerController thePlayer;
	private Camera theCamera;

	public string pointName;
	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();
		if (thePlayer.startPoint == pointName) {
			Debug.Log ("Reached");
			Debug.Log (thePlayer.Equals(null));
			thePlayer.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x,this.gameObject.transform.position.y,this.gameObject.transform.position.z);
			Debug.Log (this.gameObject.transform.position.x);
			Debug.Log (this.gameObject.transform.position.y);
			Debug.Log (this.gameObject.transform.position.z);
			theCamera = FindObjectOfType<Camera> ();
			theCamera.transform.position = new Vector3 (transform.position.x, transform.position.y, theCamera.transform.position.z);
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}

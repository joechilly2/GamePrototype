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
		//thePlayer = FindObjectOfType<PlayerController> ();
		thePlayer = GameObject.Find("Player").GetComponent<PlayerController>();
		Debug.Log ("Spawnpoint Name: " + pointName + " - Current Player Spawnpoint: " + thePlayer.startPoint);
		if (thePlayer.startPoint == pointName) {
			Debug.Log ("Player Destination: " + thePlayer.startPoint);
			Debug.Log ("Teleporting to point: " + pointName);
			Debug.Log ("Can find player: " + !thePlayer.Equals(null));
			thePlayer.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x,this.gameObject.transform.position.y,this.gameObject.transform.position.z);
			Debug.Log ("X Coord: " + this.gameObject.transform.position.x);
			Debug.Log ("Y Coord: " + this.gameObject.transform.position.y);
			theCamera = FindObjectOfType<Camera> ();
			theCamera.transform.position = new Vector3 (transform.position.x, transform.position.y, theCamera.transform.position.z);
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}

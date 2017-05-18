using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour {

	//Put onto trigger areas that will transport the player to another level
	//relatively simnple, it uses a string system to find playerstartpoints in the other level

	//POSSIBLE UPDATE: Replace the strings with some sort of tagging system or look for the areas
	//by name instead of a predefined string.

	public string levelToLoad;

	private PlayerController thePlayer;

	public string exitPoint;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "Player") {
			thePlayer.startPoint = exitPoint;
			SceneManager.LoadScene(levelToLoad);
		}
	}

}

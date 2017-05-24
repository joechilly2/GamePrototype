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

	public bool pressToLoad;

	private PlayerController thePlayer;

	public string exitPoint;

	private float countdown = 0.1f;
	private bool isSwapping = false;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (isSwapping) {
			countdown -= Time.deltaTime;
			if(countdown <= 0){
				SceneManager.LoadScene(levelToLoad);
			}
		}
	}

	void OnTriggerStay2D(Collider2D other){
		if (!pressToLoad) {
			if (other.gameObject.name == "Player") {
				thePlayer.startPoint = exitPoint;
				other.GetComponent<PlayerController> ().startPoint = exitPoint;
				Debug.Log ("Moving to point:" + thePlayer.startPoint);
				InitiateLevelSwap ();
			}
		}
		if (pressToLoad) {
			if (other.gameObject.name == "Player" && Input.GetKeyDown (KeyCode.Space)) {
				thePlayer.startPoint = exitPoint;
				other.GetComponent<PlayerController> ().startPoint = exitPoint;
				Debug.Log ("Moving to point:" + thePlayer.startPoint);
				SceneManager.LoadScene(levelToLoad);
			}
		}
	}

	void InitiateLevelSwap(){
		isSwapping = true;
	}

}

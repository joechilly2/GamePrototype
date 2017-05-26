using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueHolder : MonoBehaviour {

	//Script that is put on objects that have interaction areas
	//Currently used on NPCs but could be used on objects aswell
	//or really anywhere that needs some sort of dialogue box

	public string dialogue;
	private DialogueManager dMan;

	private bool inArea;

	// Use this for initialization
	void Start () {
		dMan = FindObjectOfType<DialogueManager> ();
		inArea = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (dMan.dBox.activeInHierarchy && Input.GetKeyDown (KeyCode.Space) && inArea) {
			dMan.dBox.SetActive (false);

		}
		else if (Input.GetKeyDown (KeyCode.E) && !dMan.dBox.activeInHierarchy && inArea) {
			if (this.gameObject.GetComponent<OpenChest> () != null) {
				Debug.Log ("Test");
				this.gameObject.GetComponent<OpenChest> ().SetOpenChest (true);
			}
			dMan.ShowBox (dialogue);
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "Player") {
			inArea = true;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.name == "Player") {
			inArea = false;
			dMan.dBox.SetActive (false);
		}
	}
}

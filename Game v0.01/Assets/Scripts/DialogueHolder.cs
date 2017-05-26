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

	public string[] dialogLines;
	public int currentLine = -1;

	private bool inArea;

	// Use this for initialization
	void Start () {
		dMan = FindObjectOfType<DialogueManager> ();
		inArea = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (dMan.dBox.activeInHierarchy && Input.GetKeyDown (KeyCode.E) && inArea && currentLine+1 >= dialogLines.Length) {
			dMan.dBox.SetActive (false);
			currentLine = -1;
		}

		else if (Input.GetKeyDown (KeyCode.E) && !dMan.dBox.activeInHierarchy && inArea && currentLine < dialogLines.Length) {
			//For Chests...
			if (this.gameObject.GetComponent<OpenChest> () != null) {
				this.gameObject.GetComponent<OpenChest> ().SetOpenChest (true);
			}
			currentLine++;
			dMan.ShowBox (dialogLines[currentLine]);
		}
		else if(Input.GetKeyDown (KeyCode.E) && dMan.dBox.activeInHierarchy && inArea && currentLine < dialogLines.Length){
			//For Chests...
			if (this.gameObject.GetComponent<OpenChest> () != null) {
				this.gameObject.GetComponent<OpenChest> ().SetOpenChest (true);
			}
			currentLine++;
			dMan.ShowBox (dialogLines[currentLine]);
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
			currentLine = 0;
		}
	}

	public bool hasNextLine(){
		if (dialogLines [currentLine + 1] != null) {
			return true;
		}
		return false;
	}
}

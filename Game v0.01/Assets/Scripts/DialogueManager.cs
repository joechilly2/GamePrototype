using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	//Manager that is put onto canvas component that holds
	//dialogue box. Only 1 of these should exist in the game

	public GameObject dBox;
	public Text dText;

	public bool dialogueActive;

	// Use this for initialization
	void Start () {
		dBox.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		/*if (dialogueActive && Input.GetKeyDown(KeyCode.Space)) {
			dBox.SetActive (false);
			dialogueActive = false;
		}*/
	}

	public void ShowBox(string dialogue){
		dialogueActive = true;
		dBox.SetActive (true);
		dText.text = dialogue;
	}

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractAreaProperties : MonoBehaviour {

	//UNUSED. If this is causing any errors please delete it
	//Replaced with dialogue manager script

	public string[] text;
	private string currentText;

	private int textArrayRover;
	private int maxTextLength;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void NextText(){
		if (textArrayRover >= maxTextLength) {
			textArrayRover = 0;
			currentText = text[textArrayRover];
		} else {
			textArrayRover++;
			currentText = text[textArrayRover];
		}
	}

	public string GetText(){
		string text = currentText;
		return text;
	}
}

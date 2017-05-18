using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionAreas : MonoBehaviour {

	//UNUSED. If this is causing any errors please delete it
	//Replaced with dialogue manager script

	public Collider2D interactUp;
	public Collider2D interactDown;
	public Collider2D interactLeft;
	public Collider2D interactRight;

	private string currentText;
	private bool inArea;

	public DialogueManager dBox;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void ClearActiveDirections(){
		interactUp.gameObject.SetActive (false);
		interactDown.gameObject.SetActive (false);
		interactLeft.gameObject.SetActive (false);
		interactRight.gameObject.SetActive (false);
	}

	public void SetText(string s){
		currentText = s;
	}

	public void TriggerInteract(){
		//if(inArea == true){
			Debug.Log ("We got close!");
			dBox.ShowBox (currentText);
		//}
	}

	public void setAreaTrue(){
		inArea = true;
	}
}

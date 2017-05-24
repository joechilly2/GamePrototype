using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSystem : MonoBehaviour {

	public Image menu;
	public Text inventory;
	public PlayerController thePlayer;

	private bool menuIsActive = false;
	private string[] invent = { "", "", "", "", "" };


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			ToggleMenu ();
		}
		if(menuIsActive){
			
		}

	}

	void ToggleMenu(){
		menu.gameObject.SetActive (!menu.isActiveAndEnabled);
		menuIsActive = !menuIsActive;
		//thePlayer.enabled = !thePlayer.enabled;
	}
}

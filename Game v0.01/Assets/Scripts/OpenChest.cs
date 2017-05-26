using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour {

	public string key;
	public bool hasHealthPotion;

	private bool open;
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		open = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (open) {
			anim.SetBool ("ChestOpen", open);
			if (key != "") {
				GameObject.FindGameObjectWithTag ("GlobalValueHolder").GetComponent<GlobalValueHolder> ().UnlockRoom (key);
			}
			if (hasHealthPotion) {
				GameObject.FindGameObjectWithTag ("GlobalValueHolder").GetComponent<GlobalValueHolder> ().AddHealthPotion ();
				GameObject.FindGameObjectWithTag ("GlobalValueHolder").GetComponent<GlobalValueHolder> ().spawnChestOpened = true;
				hasHealthPotion = false;
			}
		}
	}

	public void SetOpenChest(bool b){
		open = b;
	}
}

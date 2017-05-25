using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLayerChanger : MonoBehaviour {

	private string startingLayer;
	private int startingOrder;

	public string layerToChange;
	public int orderToChange;

	// Use this for initialization
	void Start () {
		startingLayer = gameObject.GetComponent<SpriteRenderer> ().sortingLayerName;
		startingOrder = gameObject.GetComponent<SpriteRenderer> ().sortingOrder;
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name == "Player") {
			gameObject.GetComponent<SpriteRenderer> ().sortingLayerName = layerToChange;
			gameObject.GetComponent<SpriteRenderer> ().sortingOrder = orderToChange;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.name == "Player") {
			gameObject.GetComponent<SpriteRenderer> ().sortingLayerName = startingLayer;
			gameObject.GetComponent<SpriteRenderer> ().sortingOrder = startingOrder;
		}
	}
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonControllerFollowArea : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		this.transform.parent.gameObject.GetComponent<SkeletonController> ().SkeletonTriggerEnter (other);
	}

	void OnTriggerExit2D(Collider2D other) {
		this.transform.parent.gameObject.GetComponent<SkeletonController> ().SkeletonTriggerExit (other);
	}

}

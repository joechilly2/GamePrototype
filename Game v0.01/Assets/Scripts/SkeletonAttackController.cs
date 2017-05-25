using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttackController : MonoBehaviour {

	private float freezeCounter = .5f;
	private float freezeTimer;
	private bool isAttacking;

	// Use this for initialization
	void Start () {
		freezeTimer = freezeCounter;
	}
	
	// Update is called once per frame
	void Update () {
		if (isAttacking) {
			freezeTimer -= Time.deltaTime;
			if (freezeTimer <= 0) {
				gameObject.GetComponentInParent<SkeletonController> ().isAttacking = false;
				isAttacking = false;
			}
		} else {
			freezeTimer = freezeCounter;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.name == "Player") {
			gameObject.GetComponentInParent<Animator> ().SetBool ("IsAttacking", true);
			gameObject.GetComponentInParent<SkeletonController> ().isAttacking = true;
			isAttacking = true;
		}
	}
}

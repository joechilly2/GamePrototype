using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerMovement : MonoBehaviour
{

	//Similar to PlayerController and SlimeController
	//Gives a set area that an npc can walk around in.
	//Probably easier just to have npcs who are just sitting still,
	//but this script can be used if needed
	//(Doesnt handle any animation currently)
	//Attach this to the NPC gameobjects themselves

	public float moveSpeed;

	public float walkTime;
	private float walkCounter;
	public float waitTime;
	private float waitCounter;

	private Rigidbody2D myRigidBody;

	public bool isWalking;
	private bool hasWalkZone;

	private int WalkDirection;

	public Collider2D walkZone;
	private Vector2 minWalkPoint;
	private Vector2 maxWalkPoint;

	// Use this for initialization
	void Start ()
	{
		myRigidBody = GetComponent<Rigidbody2D> ();

		waitCounter = waitTime;
		walkCounter = walkTime;

		ChooseDirection ();
		hasWalkZone = false;

		if (walkZone != null) {
			hasWalkZone = true;
			minWalkPoint = walkZone.bounds.min;
			maxWalkPoint = walkZone.bounds.max;
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isWalking) {
			walkCounter -= Time.deltaTime;

			switch (WalkDirection) {
			case 0:
				myRigidBody.velocity = new Vector2 (0, moveSpeed);
				if (hasWalkZone && transform.position.y > maxWalkPoint.y) {
					isWalking = false;
					waitCounter = waitTime;
				}
				break;
			case 1:
				myRigidBody.velocity = new Vector2 (moveSpeed, 0);
				if (hasWalkZone && transform.position.x > maxWalkPoint.x) {
					isWalking = false;
					waitCounter = waitTime;
				}
				break;
			case 2:
				myRigidBody.velocity = new Vector2 (0, -moveSpeed);
				if (hasWalkZone && transform.position.y < minWalkPoint.y) {
					isWalking = false;
					waitCounter = waitTime;
				}
				break;
			case 3:
				myRigidBody.velocity = new Vector2 (-moveSpeed, 0);
				if (hasWalkZone && transform.position.x < minWalkPoint.x) {
					isWalking = false;
					waitCounter = waitTime;
				}
				break;
			}

			if (walkCounter < 0) {
				isWalking = false;
				waitCounter = waitTime;
			}

		} else {
			waitCounter -= Time.deltaTime;

			myRigidBody.velocity = Vector2.zero;

			if (waitCounter < 0) {
				ChooseDirection ();
			}
		}
	}

	public void ChooseDirection ()
	{
		WalkDirection = Random.Range (0, 4);
		isWalking = true;
		walkCounter = walkTime;
	}
}

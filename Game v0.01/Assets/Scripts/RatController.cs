using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatController : MonoBehaviour {

	private Rigidbody2D enemyRigidBody;

	public Collider2D trigger;
	public Collider2D collisionn;

	private bool moving;
	public float moveSpeed;
	public float timeBetweenMove;
	private float timeBetweenMoveCounter;
	public float timeToMove;
	private float timeToMoveCounter;
	private Vector3 moveDirection;

	public float waitToReload;
	private GameObject thePlayer;

	private bool targetPlayer = false;

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		enemyRigidBody = GetComponent<Rigidbody2D> ();

		//Constant move times
		//timeBetweenMoveCounter = timeBetweenMove;
		//timeToMoveCounter = timeToMove;

		//Variating move times
		timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
		timeToMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("IsMoving", moving);
		if (!targetPlayer) {
			if (moving) {//If the enemy is moving
				timeToMoveCounter -= Time.deltaTime;
				enemyRigidBody.velocity = moveDirection;

				//When its time to stop moving
				if (timeToMoveCounter < 0f) {
					moving = false;

					//timeBetweenMoveCounter = timeToMove;
					timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
				}


			} else {//If the enemy isnt moving
				timeBetweenMoveCounter -= Time.deltaTime;
				enemyRigidBody.velocity = Vector2.zero;

				//When its time to move...
				if (timeBetweenMoveCounter < 0f) {
					moving = true;

					//timeToMoveCounter = timeToMove;
					timeToMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);

					moveDirection = new Vector3 (Random.Range (-.5f, .5f) * moveSpeed, Random.Range (-.5f, .5f) * moveSpeed, 0f);


					anim.SetFloat ("MoveX", 0f);
					anim.SetFloat ("MoveY", 0f);
					anim.SetFloat ("LastMoveX", 0f);
					anim.SetFloat ("LastMoveY", 0f);
					if(moveDirection.y >= 0){
						if (moveDirection.y >= moveDirection.x) {
							//Move Up
							anim.SetFloat ("MoveY", 1f);
							anim.SetFloat ("LastMoveY", 1f);
						}
						else{
							//Move Right
							anim.SetFloat ("MoveX", 1f);
							anim.SetFloat ("LastMoveX", 1f);
						}
					}
					else if(moveDirection.y <= 0){
						if (moveDirection.y <= moveDirection.x) {
							//Move Down
							anim.SetFloat ("MoveY", -1f);
							anim.SetFloat ("LastMoveY", -1f);
						}
						else{
							//Move Left
							anim.SetFloat ("MoveX", -1f);
							anim.SetFloat ("LastMoveX", -1f);
						}
					}

				}
			}
		} else {
			anim.SetBool ("IsMoving", true);
			transform.position = Vector2.MoveTowards(transform.position, thePlayer.transform.position, (moveSpeed * Time.deltaTime)*0.4f);
			anim.SetFloat ("MoveX", 0f);
			anim.SetFloat ("MoveY", 0f);
			anim.SetFloat ("LastMoveX", 0f);
			anim.SetFloat ("LastMoveY", 0f);
			if(transform.position.x - thePlayer.transform.position.x >= 0f){
				if (transform.position.x - thePlayer.transform.position.x >= transform.position.y - thePlayer.transform.position.y) {
					//Move Up
					anim.SetFloat ("MoveX", -1f);
					anim.SetFloat ("LastMoveX", -1f);
				}
				else{
					//Move Right
					anim.SetFloat ("MoveY", -1f);
					anim.SetFloat ("LastMoveY", -1f);
				}
			}
			else if(transform.position.x - thePlayer.transform.position.x <= 0f){
				if (transform.position.x - thePlayer.transform.position.x <= transform.position.y - thePlayer.transform.position.y) {
					//Move Down
					anim.SetFloat ("MoveX", 1f);
					anim.SetFloat ("LastMoveX", 1f);
				}
				else{
					//Move Left
					anim.SetFloat ("MoveY", 1f);
					anim.SetFloat ("LastMoveY", 1f);
				}
			}
		}
	}

	public void RatTriggerEnter(Collider2D other) {
		if (other.gameObject.name == "Player") {
			thePlayer = other.gameObject;
			targetPlayer = true;
		}
	}

	public void RatTriggerExit(Collider2D other) {
		if (other.gameObject.name == "Player") {
			targetPlayer = false;
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.name == "Player") {
			Physics2D.IgnoreCollision(other.collider,this.gameObject.GetComponent<Collider2D>());
		}
	}

	void OnCollisionStay2D(Collision2D other){
		if (!targetPlayer) {
			moving = true;
			timeToMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
			moveDirection = new Vector3 (Random.Range (-.5f, .5f) * moveSpeed, Random.Range (-.5f, .5f) * moveSpeed, 0f);
			anim.SetFloat ("MoveX", 0f);
			anim.SetFloat ("MoveY", 0f);
			anim.SetFloat ("LastMoveX", 0f);
			anim.SetFloat ("LastMoveY", 0f);
			if(moveDirection.y >= 0){
				if (moveDirection.y >= moveDirection.x) {
					//Move Up
					anim.SetFloat ("MoveY", 1f);
					anim.SetFloat ("LastMoveY", 1f);
				}
				else{
					//Move Right
					anim.SetFloat ("MoveX", 1f);
					anim.SetFloat ("LastMoveX", 1f);
				}
			}
			else if(moveDirection.y <= 0){
				if (moveDirection.y <= moveDirection.x) {
					//Move Down
					anim.SetFloat ("MoveY", -1f);
					anim.SetFloat ("LastMoveY", -1f);
				}
				else{
					//Move Left
					anim.SetFloat ("MoveX", -1f);
					anim.SetFloat ("LastMoveX", -1f);
				}
			}
		}
	}

}

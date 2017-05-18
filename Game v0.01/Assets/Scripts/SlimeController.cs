using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeController : MonoBehaviour {

	//Similar to PlayerController, this handles movement for enemy slimes
	//Is attached to enemy characters
	//**Extremely basic random movement, could / should be changed to follow player


	private Rigidbody2D enemyRigidBody;

	private bool moving;
	public float moveSpeed;
	public float timeBetweenMove;
	private float timeBetweenMoveCounter;
	public float timeToMove;
	private float timeToMoveCounter;
	private Vector3 moveDirection;

	public float waitToReload;
	private bool reloading;
	private GameObject thePlayer;

	void Start () {
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

				moveDirection = new Vector3 (Random.Range(-.5f,.5f) * moveSpeed,Random.Range(-.5f,.5f) * moveSpeed,0f);
			}
		}

		if (reloading) {
			waitToReload -= Time.deltaTime;
			if (waitToReload < 0) {
				SceneManager.LoadScene (SceneManager.GetActiveScene().name);
				thePlayer.SetActive(true);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		/*if (other.gameObject.name == "Player") {
			other.gameObject.SetActive (false);
			reloading = true;
			thePlayer = other.gameObject;
		}
		*/
	}

	public void StunEnemy(){
		moving = false;
		enemyRigidBody.velocity = Vector2.zero;
		timeBetweenMoveCounter = Random.Range (timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
	}

}

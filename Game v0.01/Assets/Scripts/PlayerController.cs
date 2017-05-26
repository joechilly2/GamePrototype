using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

	//Probably the most complicated script so far
	//Is put onto the player object
	//Controls movespeed, movement animations, handling attacking, etc
	//Also controls attack times and when the player can attack
	//Controls where the player will spawn on a level (Ties to LoadNewArea)


	public float moveSpeed;
	private float currentMoveSpeed;
	//public float diagonalMoveModifier;

	private Animator anim;
	private Rigidbody2D playerRigidbody;

	private bool playerMoving;
	private Vector2 lastMove;
	private Vector2 moveInput;

	private static bool playerExists = false;

	private bool attacking;
	public float attackTime = 1f;
	private float attackTimeCounter;

	public string startPoint;

	public bool invulnurable = false;
	private float invulntime = 1.5f;
	private float invulntimer = 1.5f;

	private bool attackingDown;
	private bool attackingUp;
	private bool attackingLeft;
	private bool attackingRight;

	public Collider2D boxAttackingDown;
	public Collider2D boxAttackingUp;
	public Collider2D boxAttackingLeft;
	public Collider2D boxAttackingRight;

	//public PlayerInteractionAreas interactions;
	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();
		playerRigidbody = GetComponent<Rigidbody2D> ();
		moveSpeed = 4f;

		if (!playerExists) {
			playerExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy (gameObject);
		}

		lastMove = new Vector2 (0, -1f);

		boxAttackingUp.gameObject.GetComponent<HurtEnemy> ().enabled = false;
		boxAttackingDown.gameObject.GetComponent<HurtEnemy> ().enabled = false;
		boxAttackingRight.gameObject.GetComponent<HurtEnemy> ().enabled = false;
		boxAttackingLeft.gameObject.GetComponent<HurtEnemy> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
//		Debug.Log ("Up: " + boxAttackingUp.gameObject.GetComponent<HurtEnemy> ().enabled);
//		Debug.Log ("Down: " + boxAttackingDown.gameObject.GetComponent<HurtEnemy> ().enabled);
//		Debug.Log ("Left: " + boxAttackingLeft.gameObject.GetComponent<HurtEnemy> ().enabled);
//		Debug.Log ("Right: " + boxAttackingRight.gameObject.GetComponent<HurtEnemy> ().enabled);
		if (invulnurable) {
			invulntimer -= Time.deltaTime;
			if (invulntimer <= 0) {
				invulnurable = false;
				invulntimer = invulntime;
			}
		}

		playerMoving = false;
		if (!attacking) {

			/*if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw ("Horizontal") < -0.5f) {
				//transform.Translate (new Vector3 (Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime, 0f));
				playerRigidbody.velocity = new Vector2 (Input.GetAxisRaw ("Horizontal") * currentMoveSpeed, playerRigidbody.velocity.y);
				playerMoving = true;
				lastMove = new Vector3 (Input.GetAxisRaw ("Horizontal"), 0f);
			}

			if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw ("Vertical") < -0.5f) {
				//transform.Translate (new Vector3 (0f, Input.GetAxisRaw ("Vertical") * moveSpeed * Time.deltaTime));
				playerRigidbody.velocity = new Vector2 (playerRigidbody.velocity.x, Input.GetAxisRaw ("Vertical") * currentMoveSpeed);
				playerMoving = true;
				lastMove = new Vector3 (0f, Input.GetAxisRaw ("Vertical"));
			}

			if (Input.GetAxisRaw ("Horizontal") < 0.5f && Input.GetAxisRaw ("Horizontal") > -0.5f) {
				playerRigidbody.velocity = new Vector2 (0f, playerRigidbody.velocity.y);
			}

			if (Input.GetAxisRaw ("Vertical") < 0.5f && Input.GetAxisRaw ("Vertical") > -0.5f) {
				playerRigidbody.velocity = new Vector2 (playerRigidbody.velocity.x, 0f);
			} */

			moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

			if (moveInput != Vector2.zero) {
				playerRigidbody.velocity = new Vector2 (moveInput.x * moveSpeed, moveInput.y * moveSpeed);
				playerMoving = true;
				lastMove = moveInput;
			} else {
				playerRigidbody.velocity = Vector2.zero;
			}

			if (Input.GetKeyDown (KeyCode.Space)) {
				attackTimeCounter = attackTime;
				attacking = true;
				playerRigidbody.velocity = Vector2.zero;
				anim.SetBool ("Attack", true);
			}

			/*if (Mathf.Abs (Input.GetAxisRaw ("Horizontal")) > 0.5f && Mathf.Abs (Input.GetAxisRaw ("Vertical")) > 0.5f) {
				currentMoveSpeed = moveSpeed * diagonalMoveModifier;
			} else {
				currentMoveSpeed = moveSpeed;
			}*/
		}

		if (attackTimeCounter > 0) {
			attackTimeCounter -= Time.deltaTime;
		}
		if (attackTimeCounter <= 0) {
			attacking = false;
			anim.SetBool ("Attack", false);
		}


		anim.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal"));
		anim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));
		anim.SetBool ("PlayerMoving", playerMoving);
		anim.SetFloat ("LastMoveX", lastMove.x);
		anim.SetFloat ("LastMoveY", lastMove.y);

		/*interactions.ClearActiveDirections ();
		if (lastMove.x > 0.5f) {
			interactions.interactRight.gameObject.SetActive (true);
			if (Input.GetKeyDown (KeyCode.E)) {
				Debug.Log ("Right");
				//interactions.ClearActiveDirections ();
				interactions.TriggerInteract ();
			}
		}
		if (lastMove.x < -0.5f) {
			interactions.interactLeft.gameObject.SetActive (true);
			if (Input.GetKeyDown (KeyCode.E)) {
				Debug.Log ("Left");
				//interactions.ClearActiveDirections ();
				interactions.TriggerInteract ();
			}
		}
		if (lastMove.y > 0.5f) {
			interactions.interactUp.gameObject.SetActive (true);
			if (Input.GetKeyDown (KeyCode.E)) {
				Debug.Log ("Up");
				//interactions.ClearActiveDirections ();
				interactions.TriggerInteract ();
			}
		}
		if (lastMove.y < -0.5f) {
			interactions.interactDown.gameObject.SetActive (true);
			if (Input.GetKeyDown (KeyCode.E)) {
				Debug.Log ("Down");
				//interactions.ClearActiveDirections ();
				interactions.TriggerInteract ();
			}
		}
		*/
	}

	public void ToggleUpBox(){
		attackingUp = !attackingUp;
		boxAttackingUp.gameObject.GetComponent<HurtEnemy> ().enabled = !boxAttackingUp.gameObject.GetComponent<HurtEnemy> ().enabled;
		//Debug.Log ("AttackedUp");
	}

	public void ToggleDownBox(){
		attackingDown = !attackingDown;
		boxAttackingDown.gameObject.GetComponent<HurtEnemy> ().enabled = !boxAttackingDown.gameObject.GetComponent<HurtEnemy> ().enabled;
	}

	public void ToggleRightBox(){
		attackingRight = !attackingRight;
		boxAttackingRight.gameObject.GetComponent<HurtEnemy> ().enabled = !boxAttackingRight.gameObject.GetComponent<HurtEnemy> ().enabled;
	}

	public void ToggleLeftBox(){
		attackingLeft = !attackingLeft;
		boxAttackingLeft.gameObject.GetComponent<HurtEnemy> ().enabled = !boxAttackingLeft.gameObject.GetComponent<HurtEnemy> ().enabled;
	}

	public bool checkDirection(string s){
		switch (s) {
		case("Up"):
			return attackingUp;
			break;
		case("Down"):
			return attackingDown;
			break;
		case("Left"):
			return attackingLeft;
			break;
		case("Right"):
			return attackingRight;
			break;
		}
		return false;
	}


}
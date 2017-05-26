using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour {

	//Script used to calculate when to damage enemies
	//Is put onto items / areas that damage enemies, not the
	//enemies themselves.

	//KNOWN BUGS: sometimes when enemies are in the same spot and the player doesnt move while attacking,
	//on the second / third sword throw the enemies isnt damaged.

	//POSSIBLE FIX: briefly transport this gameobject across the map to a far away location then back to where
	//It was previously to cause ontriggerenter2d to trigger again.
	//public ArrayList currentHitEnemies = new ArrayList();

	public int damageToGive;

	public GameObject damageBurst;
	public GameObject damageNumber;

	public string direction;

	private float invulnTime = 0.25f;
	private float invulnTimer;
	private bool isInvuln = false;

	// Use this for initialization
	void Start ()
	{
		invulnTimer = invulnTime;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isInvuln) {
			invulnTimer -= Time.deltaTime;
			if (invulnTimer <= 0) {
				isInvuln = false;
//				currentHitEnemies.Clear ();
				invulnTimer = invulnTime;
			}
		} else {
			invulnTimer = invulnTime;
		}
	}

	void OnTriggerStay2D (Collider2D other)
	{
		//Debug.Log (direction + ": " + gameObject.GetComponentInParent<PlayerController> ().checkDirection (direction));
		//bool isHit = currentHitEnemies.Contains(other.gameObject);
		if (other.gameObject.tag == "Enemy" && gameObject.GetComponentInParent<PlayerController>().checkDirection(direction) && !isInvuln) {
			//currentHitEnemies.Add(other.gameObject);
			//Debug.Log (this.gameObject.name);
			//Destroy (other.gameObject);
			isInvuln = true;
			other.gameObject.GetComponent<EnemyHealthManager> ().HurtEnemy (damageToGive);
			Instantiate (damageBurst, other.transform.position, other.transform.rotation);
			//Creating objects from nothing. Very Useful!!!
			var clone = (GameObject)Instantiate (damageNumber, (new Vector3 (other.transform.position.x, other.transform.position.y + 0.4f, other.transform.position.z)), Quaternion.Euler (Vector3.zero));
			clone.GetComponent<FloatingNumbers> ().damageNumber = damageToGive;
			if (other.name == "Skeleton") {
				other.GetComponent<SkeletonController> ().StunEnemy ();
			}
		}
	}
}

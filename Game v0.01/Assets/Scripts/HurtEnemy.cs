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

	public int damageToGive;

	public GameObject damageBurst;
	public GameObject damageNumber;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Enemy") {
			//Destroy (other.gameObject);
			other.gameObject.GetComponent<EnemyHealthManager> ().HurtEnemy (damageToGive);
			other.gameObject.GetComponent<SlimeController> ().StunEnemy ();
			Instantiate (damageBurst, other.transform.position, other.transform.rotation);
			//Creating objects from nothing. Very Useful!!!
			var clone = (GameObject)Instantiate (damageNumber, (new Vector3 (other.transform.position.x, other.transform.position.y + 0.4f, other.transform.position.z)), Quaternion.Euler (Vector3.zero));
			clone.GetComponent<FloatingNumbers> ().damageNumber = damageToGive;
		}
	}
}

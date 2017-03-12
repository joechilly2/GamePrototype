using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{

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
			Instantiate (damageBurst, other.transform.position, other.transform.rotation);
			//Creating objects from nothing. Very Useful!!!
			var clone = (GameObject)Instantiate (damageNumber, (new Vector3 (other.transform.position.x, other.transform.position.y + 0.4f, other.transform.position.z)), Quaternion.Euler (Vector3.zero));
			clone.GetComponent<FloatingNumbers> ().damageNumber = damageToGive;
		}
	}
}

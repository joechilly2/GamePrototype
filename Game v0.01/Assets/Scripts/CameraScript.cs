using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	public GameObject followTarget;
	public Vector3 targetPos;
	public float moveSpeed;

	private static bool cameraExists;
	// Use this for initialization
	void Start () {
		moveSpeed = 4;

		if (!cameraExists) {
			cameraExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} else {
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, this.gameObject.transform.position.z);
		transform.position = Vector3.Lerp (transform.position, targetPos, moveSpeed * Time.deltaTime);
	}
}

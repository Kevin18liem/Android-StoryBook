using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2_BapakMobil : MonoBehaviour {

	public bool jalan = false;
	public float distance;
	public float dDist = 0.1f;
	public float moveSpeed;

	private Vector3 target;

	// Use this for initialization
	void Start () {

		target = new Vector3 (transform.position.x + distance, 
			transform.position.y,
			transform.position.z);

	}
	
	// Update is called once per frame
	void Update () {

		if (jalan) {
			if (Vector3.Distance (transform.position, target) >= dDist) {
				transform.position = Vector3.MoveTowards (transform.position, target, moveSpeed *
					Time.deltaTime);
			} else {
				transform.position = target;
				jalan = false;
			}
		}

	}
}

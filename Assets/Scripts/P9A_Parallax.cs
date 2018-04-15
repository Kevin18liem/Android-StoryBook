using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P9A_Parallax : MonoBehaviour {

	public float maxDelta;
	public float moveSpeed = 1;

	private Vector3 initPos;

	// Use this for initialization
	void Start () {

		initPos = transform.position;

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.RightArrow) && 
			Vector3.Distance(transform.position, initPos) <= maxDelta) {
			transform.position = Vector3.MoveTowards (transform.position, 
				new Vector3 (initPos.x + maxDelta, transform.position.y, transform.position.z),
				moveSpeed * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.LeftArrow) && 
			Vector3.Distance(transform.position, initPos) <= maxDelta) {
			transform.position = Vector3.MoveTowards (transform.position, 
				new Vector3 (initPos.x - maxDelta, transform.position.y, transform.position.z),
				moveSpeed * Time.deltaTime);
		}


	}
}

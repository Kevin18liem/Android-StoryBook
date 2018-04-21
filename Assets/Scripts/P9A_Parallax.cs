using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P9A_Parallax : MonoBehaviour {

	public float maxDelta;
	public float moveSpeed = 1;
	public float linear_limit;			// how long the bg can move (from -limit to limit)
	public float angle_limit = 45;		// max device rotation to linear limit
	public float movement_speed = 1;	// camera move speed
	public GameObject detector;			// rotation detector

	private float pos;					// position
	private Vector3 initPos;

	// Use this for initialization
	void Start () {

		initPos = transform.position;

		Input.gyro.enabled = true;

	}
	
	// Update is called once per frame
	void Update () {

		/*if (SystemInfo.deviceType == DeviceType.Desktop)
		{
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
		}*/

		//if (SystemInfo.deviceType == DeviceType.Handheld)
		{
			Debug.Log ("rotation= " + Input.gyro.rotationRateUnbiased.x + " " + Input.gyro.rotationRateUnbiased.y + " " + Input.gyro.rotationRateUnbiased.z);
			detector.transform.Rotate (0, Input.gyro.rotationRateUnbiased.y, 0);
			Debug.Log (detector.transform.eulerAngles);

			if (detector.transform.eulerAngles.y < 180) {
				pos = initPos.x + (detector.transform.eulerAngles.y / angle_limit) * linear_limit;
				if (pos > linear_limit) {
					pos = linear_limit;
				}

			} else {
				pos = initPos.x + ((detector.transform.eulerAngles.y - 360) / angle_limit) * linear_limit;
				if (pos < -linear_limit) {
					pos = -linear_limit;
				}
			}

			Debug.Log (pos);
			transform.position = Vector3.Lerp (transform.position, 
				new Vector3 (pos, initPos.y,initPos.z),
				movement_speed);

		}
			
	}
}

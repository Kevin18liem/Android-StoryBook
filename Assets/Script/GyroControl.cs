using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroControl : MonoBehaviour {
	private bool gyroEnabled;
	private Gyroscope gyro;
	private GameObject cameraContainer;
	private Quaternion rot;
	private float moveThreshold = .2f;
	private float speedCamera  = 0.7f;
	private float movex;
	private float iPx;
	private Vector3 lastAcc;
	private Vector3 linAcc1;
	private void Start() {
		// cameraContainer = new GameObject("Camera Container");
		// cameraContainer.transform.position = transform.position;
		// transform.SetParent(cameraContainer.transform);
		// gyroEnabled = EnableGyro();
		
	}

	// private bool EnableGyro() {
	// 	if(SystemInfo.supportsGyroscope) {
	// 		gyro = Input.gyro;
	// 		gyro.enabled = true;
	// 		cameraContainer.transform.rotation = Quaternion.Euler (90f, 90f, 0f);
	// 		rot = new Quaternion (0, 0, -1, 0);

	// 		return true;
	// 	}
	// 	return false;
	// }
	 public Vector3 linearAcceleration() {
	     linAcc1 = Input.acceleration - lastAcc;
	     lastAcc = Input.acceleration;
	     return linAcc1;
 	}
	private void Update() {
		movex = 0;
		iPx = linearAcceleration().x;
		if(Mathf.Abs(iPx) > moveThreshold) {
			movex = Mathf.Sign(iPx) * speedCamera;
    		transform.Translate(movex,0,0);
		}
		// if (gyroEnabled) {
		// 	transform.localRotation = gyro.attitude * rot;
		// }
		// hRotation -= Input.acceleration.y * cameraMovementSpeed;
  //     vRotation += Input.acceleration.x * cameraMovementSpeed;
  //     transform.rotation = Quaternion.Euler(vRotation, hRotation, 0.0f);
	}

}
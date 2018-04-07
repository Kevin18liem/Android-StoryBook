using UnityEngine;
using System.Collections;
public class SwipeTrail : MonoBehaviour {
	public GameObject trailPrefab;
	GameObject thisTrail;
	Vector3 startPos;
	Plane objPlane;
	public string KodeWarna;
	private Color warnaTertentu;
	private void Start() {
		objPlane = new Plane(Camera.main.transform.forward*-1,this.transform.position);
		KodeWarna = "black";
	}
	private void Update() {
		if(((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)|| Input.GetMouseButtonDown(0))) {
			Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			float rayDistance;
			if(objPlane.Raycast(mRay, out rayDistance))
				startPos = mRay.GetPoint(rayDistance);
			thisTrail = (GameObject) Instantiate(trailPrefab,startPos,Quaternion.identity);
				UpdateColor ();
		} else if(((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)|| Input.GetMouseButton(0))) {
			Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			float rayDistance;
			if(objPlane.Raycast(mRay,out rayDistance))
				thisTrail.transform.position = mRay.GetPoint(rayDistance);
		}
	}

	private void UpdateColor() {
		if (KodeWarna == "black") {
				thisTrail.GetComponent<TrailRenderer> ().startColor = Color.black;
				thisTrail.GetComponent<TrailRenderer> ().endColor = Color.black;
		} else if (KodeWarna == "red") {
			warnaTertentu = new Color32(247,59,4,255);			
			thisTrail.GetComponent<TrailRenderer> ().startColor = warnaTertentu;
			thisTrail.GetComponent<TrailRenderer> ().endColor = warnaTertentu;
		} else if (KodeWarna == "light green") {
			warnaTertentu = new Color32(197,205,67,255);
			thisTrail.GetComponent<TrailRenderer> ().startColor = warnaTertentu;
			thisTrail.GetComponent<TrailRenderer> ().endColor = warnaTertentu;
		} else if (KodeWarna == "yellow") {
			warnaTertentu = new Color32 (255, 204, 0, 255);
			thisTrail.GetComponent<TrailRenderer> ().startColor = warnaTertentu;
			thisTrail.GetComponent<TrailRenderer> ().endColor = warnaTertentu;
		} else if (KodeWarna == "dark blue") {
			warnaTertentu = new Color32(50, 113, 164,255);
			thisTrail.GetComponent<TrailRenderer> ().startColor = warnaTertentu;
			thisTrail.GetComponent<TrailRenderer> ().endColor = warnaTertentu;
		} else if (KodeWarna == "coklat") {
			warnaTertentu = new Color32(110,36, 0,255);
			thisTrail.GetComponent<TrailRenderer> ().startColor = warnaTertentu;
			thisTrail.GetComponent<TrailRenderer> ().endColor = warnaTertentu;
		} else if (KodeWarna == "white") {
			warnaTertentu = new Color32 (246, 251, 235, 255);
			thisTrail.GetComponent<TrailRenderer> ().startColor = warnaTertentu;
			thisTrail.GetComponent<TrailRenderer> ().endColor = warnaTertentu;
			thisTrail.GetComponent<TrailRenderer> ().startWidth = 1;
			thisTrail.GetComponent<TrailRenderer> ().endWidth = 1;
		} else if (KodeWarna == "light blue") {
			warnaTertentu = new Color32(114, 197, 231,255);
			thisTrail.GetComponent<TrailRenderer> ().startColor = warnaTertentu;
			thisTrail.GetComponent<TrailRenderer> ().endColor = warnaTertentu;
		} else if (KodeWarna == "orange") {
			warnaTertentu = new Color32(253, 116,10,255);
			thisTrail.GetComponent<TrailRenderer> ().startColor = warnaTertentu;
			thisTrail.GetComponent<TrailRenderer> ().endColor = warnaTertentu;
		} else if (KodeWarna == "dark green") {
			warnaTertentu = new Color32(107,146,59,255);
			thisTrail.GetComponent<TrailRenderer> ().startColor = warnaTertentu;
			thisTrail.GetComponent<TrailRenderer> ().endColor = warnaTertentu;
		} else if (KodeWarna == "cream") {
			warnaTertentu = new Color32(243,175,129,255);
			thisTrail.GetComponent<TrailRenderer> ().startColor = warnaTertentu;
			thisTrail.GetComponent<TrailRenderer> ().endColor = warnaTertentu;
		} else if (KodeWarna == "yellow ochre") {
			warnaTertentu = new Color32(216,156,68,255);
			thisTrail.GetComponent<TrailRenderer> ().startColor = warnaTertentu;
			thisTrail.GetComponent<TrailRenderer> ().endColor = warnaTertentu;
		} else if (KodeWarna == "gray") {
			thisTrail.GetComponent<TrailRenderer> ().startColor = Color.gray;
			thisTrail.GetComponent<TrailRenderer> ().endColor = Color.gray;
		}
	}
}
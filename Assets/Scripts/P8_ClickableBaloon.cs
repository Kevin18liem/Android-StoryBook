using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class P8_ClickableBaloon : MonoBehaviour {

	public string targetScene;
	public bool allowClick = false;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began) && allowClick)
		{
			Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			RaycastHit raycastHit;
			if (Physics.Raycast(raycast, out raycastHit))
			{
				if (raycastHit.collider.name == gameObject.name)
				{
					SceneManager.LoadScene (targetScene);
				}

			}
		} else if (Input.GetMouseButtonDown(0) && allowClick) {
			Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit raycastHit;
			if (Physics.Raycast(raycast, out raycastHit))
			{
				if (raycastHit.collider.name == gameObject.name)
				{
					SceneManager.LoadScene (targetScene);
				}

			}
		}

	}
}

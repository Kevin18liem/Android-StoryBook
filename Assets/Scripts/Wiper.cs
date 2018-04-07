using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiper : MonoBehaviour {
	Texture2D texture;
	Color myColor;
	Vector3 temp, offset;
	float dist;
	int xpos;
	int ypos;

	public int boxSize = 10;

	// Use this for initialization
	void Start () {
		myColor = new Color (1f, 1f, 1f, 0f);

		Texture mainTexture = GetComponent<Renderer>().material.mainTexture;
		texture = new Texture2D(mainTexture.width, mainTexture.height, TextureFormat.RGBA32, false);

		RenderTexture currentRT = RenderTexture.active;

		RenderTexture renderTexture = new RenderTexture(mainTexture.width, mainTexture.height, 32);
		Graphics.Blit(mainTexture, renderTexture);

		RenderTexture.active = renderTexture;
		texture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
		texture.Apply();

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButton(0)) {
			Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit raycastHit;
			if (Physics.Raycast(raycast, out raycastHit))
			{
				Debug.Log ("Hit " + raycastHit.collider.name);


				if (raycastHit.collider.name == gameObject.name)
				{
					Debug.Log ("Hit " + raycastHit.collider.name );
					/*dist = transform.position.z - Camera.main.transform.position.z;
					temp = new Vector3 (Input.mousePosition.x, Input.mousePosition.y,
						dist);
					temp = Camera.main.ScreenToWorldPoint (temp);
					offset = transform.position - temp;
					Debug.Log (temp.x + " " + temp.y);*/

					Debug.Log ("Size: " + texture.width + "," + texture.height + "---" + Screen.width + "," + Screen.height);

					xpos = (int)(((float)Screen.width/texture.width) * Input.mousePosition.x);
					Debug.Log (Screen.width + " / " + texture.width + " * " + Input.mousePosition.x + " = " + xpos);
					ypos = (int)(((float)Screen.height/texture.height) * Input.mousePosition.y);
					Debug.Log (Screen.height + " / " + texture.height + " * " + Input.mousePosition.y + " = " + ypos);
					Debug.Log (Screen.height + " / " + texture.height + " = " + Screen.height/texture.height);


					Debug.Log ("Pos: " + xpos + "," + ypos + "---" + Input.mousePosition.x + "," + Input.mousePosition.y);

					for (int i = xpos - boxSize; i < xpos + boxSize; i++) {
						for (int j = ypos - boxSize; j < ypos + boxSize; j++) {
							if (i <= texture.width && i >= 0 && j <= texture.height && j >= 0)
							texture.SetPixel(-1*i, j, myColor); //set pixel (0,0) to the color specified
						}
					}

					texture.Apply();			
					GetComponent<Renderer>().material.mainTexture = texture;

				}

			}
		}

	}
}

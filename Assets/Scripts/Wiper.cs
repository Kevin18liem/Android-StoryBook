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

	public int boxSize = 500;

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
				xpos = 0;
				ypos = 0;
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

					if (Input.mousePosition.y > 384) {
						ypos = ypos + (int)Input.mousePosition.y;
					} else {
						ypos = (int)Input.mousePosition.y;
					}
//					if (Input.mousePosition.x < 300) {
//						xpos = (int)Input.mousePosition.x;
//					} else if (Input.mousePosition.x > 400) {
//						xpos = xpos + (int)Input.mousePosition.x;
//					} else {
//						xpos = (int)Input.mousePosition.x;
//					}
					if (Input.mousePosition.x > 150) {
						xpos = xpos + (int)Input.mousePosition.x - (int)(150*(float)(Input.mousePosition.x/1024));
					}
					xpos += 75;
					//					ypos += 384;

					//					xpos = xpos + (int)(((float)Screen.width/texture.width) * Input.mousePosition.x);
					//					Debug.Log (Screen.width + " / " + texture.width + " * " + Input.mousePosition.x + " = " + xpos);
					//					ypos = ypos + (int)(((float)Screen.height/texture.height) * Input.mousePosition.y);
					//					Debug.Log (Screen.height + " / " + texture.height + " * " + Input.mousePosition.y + " = " + ypos);
					//					Debug.Log (Screen.height + " / " + texture.height + " = " + Screen.height/texture.height);


					Debug.Log ("Pos: " + xpos + "," + ypos + "---" + Input.mousePosition.x + "," + Input.mousePosition.y);

					for (int i = xpos-10; i < xpos + boxSize; i++) {
						for (int j = ypos-10; j < ypos + boxSize; j++) {
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

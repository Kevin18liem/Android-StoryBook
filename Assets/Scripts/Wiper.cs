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

	// Use this for initialization
	void Start () {
		myColor = new Color (1f, 0f, 0f, 1f);

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
			Debug.Log ("mouse pressed");
			Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit raycastHit;
			if (Physics.Raycast(raycast, out raycastHit))
			{
				Debug.Log ("Hit " + raycastHit.collider.name);
				Debug.DrawRay(Input.mousePosition, Vector3.forward, Color.red,100);
				Debug.DrawRay(new Vector3(0,0,0), Vector3.forward, Color.red,100);

				if (raycastHit.collider.name == gameObject.name)
				{
					Debug.Log ("Hit Plane");
					/*dist = transform.position.z - Camera.main.transform.position.z;
					temp = new Vector3 (Input.mousePosition.x, Input.mousePosition.y,
						dist);
					temp = Camera.main.ScreenToWorldPoint (temp);
					offset = transform.position - temp;
					Debug.Log (temp.x + " " + temp.y);*/
					Debug.Log (raycastHit.textureCoord);

					xpos = (int)(raycastHit.textureCoord2.x * 1024);
					ypos = (int)(raycastHit.textureCoord2.y * 768);

					//texture = new Texture2D(1024, 768);
					// GetComponent<Renderer>().material.mainTexture = texture;

					Debug.Log (xpos + " " + ypos);
					texture.SetPixel(xpos, ypos, myColor); //set pixel (0,0) to the color specified
					texture.Apply();			
					GetComponent<Renderer>().material.mainTexture = texture;

				}

			}
		}

	}
}

using UnityEngine;
using System.Collections;

public class BasicPainting : MonoBehaviour
{

	// the texture that i will paint with and the original texture (for saving)
	public Texture2D targetTexture, originalTexture ;
	//temporary texture
	public Texture2D tmpTexture;

	void Start ()
	{
		//setting temp texture width and height 
		tmpTexture = new Texture2D (originalTexture.width, originalTexture.height);
		//fill the new texture with the original one (to avoid "empty" pixels)
		for (int y =0; y<tmpTexture.height; y++) {
			for (int x = 0; x<tmpTexture.width; x++) {
				tmpTexture.SetPixel (x, y, originalTexture.GetPixel (x, y));
			}
		}
		print (tmpTexture.height);
		//filling a part of the temporary texture with the target texture 
		for (int y =0; y<tmpTexture.height-40; y++) {
			for (int x = 0; x<tmpTexture.width; x++) {
				tmpTexture.SetPixel (x, y, targetTexture.GetPixel (x, y));

			}
		}
		//Apply 
		tmpTexture.Apply ();
		//change the object main texture 
		GetComponent<Renderer>().material.mainTexture = tmpTexture;
	}

}
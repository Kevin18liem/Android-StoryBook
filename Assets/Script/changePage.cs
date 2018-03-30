using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changePage : MonoBehaviour {
	[SerializeField]
	public string sceneName;
	public void changeMenuScene() {
		SceneManager.LoadScene (sceneName);	
	}
}

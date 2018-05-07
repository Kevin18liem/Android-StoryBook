using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToggleNavigation : MonoBehaviour {
	public GameObject NavigationPanel;
	public GameObject SliderPanel;
	public GameObject Grey;
	public void toggleAnimation() {
		if (NavigationPanel.activeInHierarchy) {
			NavigationPanel.SetActive (false);
			SliderPanel.SetActive (false);
			Grey.SetActive (false);
		} else {
			NavigationPanel.SetActive (true);
			SliderPanel.SetActive (true);
			Grey.SetActive (true);
		}
	}
}

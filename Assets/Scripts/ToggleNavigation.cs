using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToggleNavigation : MonoBehaviour {
	public GameObject NavigationPanel;
	public GameObject SliderPanel;
	public GameObject Grey;
	public GameObject Telepon;
	public GameObject VideoCall;
	public bool unlockTelepon = false;
	public bool unlockVideoCall = false;
	[SerializeField]
	public void toggleAnimation() {
		if (NavigationPanel.activeInHierarchy) {
			NavigationPanel.SetActive (false);
			SliderPanel.SetActive (false);
			Grey.SetActive (false);
			if (unlockTelepon) {
				Telepon.SetActive (false);
			}
			if (unlockVideoCall) {
				VideoCall.SetActive (false);
			}
			Time.timeScale = 1;
		} else {
			NavigationPanel.SetActive (true);
			SliderPanel.SetActive (true);
			Grey.SetActive (true);
			if (unlockTelepon) {
				Telepon.SetActive (true);
			} else {
				Telepon.SetActive (false);
			}
			if (unlockVideoCall) {
				VideoCall.SetActive (true);
			} else {
				VideoCall.SetActive (false);
			}
			Time.timeScale = 0;
		}
	}
}

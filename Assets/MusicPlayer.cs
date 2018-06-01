using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
	[SerializeField]
	public AudioClip partOne;
	public AudioClip partTwo;
	public AudioClip partThree;
	public AudioClip partFour;


	[SerializeField]

	private AudioSource source;

	static private MusicPlayer instance;
	static public bool seamlessPartOne = false;
	static public bool seamlessPartTwo = false;
	static public bool seamlessPartThree = false;
	static public bool seamlessPartFour = false;


	protected virtual void Awake() {
		// Singleton enforcement
		if (instance == null) {
			// Register as singleton if first
			instance = this;
			DontDestroyOnLoad(this);
		} else {
			// Self-destruct if another instance exists
			Destroy(this);
			return;
		}
	}

	protected virtual void Start() {
		// If the game starts in a menu scene, play the appropriate music
		/*
		if (!MusicPlayer.seamlessPartOne) {
			MusicPlayer.PlayPartOneMusic ();
			MusicPlayer.seamlessPartOne = true;
			MusicPlayer.seamlessPartTwo = false;
			MusicPlayer.seamlessPartThree = false;
			MusicPlayer.seamlessPartFour = false;
		} 
*/
		MusicPlayer.PlayPartOneMusic ();
	}
	static public void PlayPartOneMusic ()
	{
		if (instance != null) {
			if (instance.source != null) {
				instance.source.Stop();
				instance.source.clip = instance.partOne;
				instance.source.Play();
			}
		} else {
			Debug.LogError("Unavailable MusicPlayer component");
		}
	}

	static public void PlayPartTwoMusic ()
	{
		if (instance != null) {
			if (instance.source != null) {
				instance.source.Stop();
				instance.source.clip = instance.partTwo;
				instance.source.Play();
			}
		} else {
			Debug.LogError("Unavailable MusicPlayer component");
		}
	}
	static public void PlayPartThreeMusic ()
	{
		if (instance != null) {
			if (instance.source != null) {
				instance.source.Stop();
				instance.source.clip = instance.partThree;
				instance.source.Play();
			}
		} else {
			Debug.LogError("Unavailable MusicPlayer component");
		}
	}
	static public void PlayPartFourMusic ()
	{
		if (instance != null) {
			if (instance.source != null) {
				instance.source.Stop();
				instance.source.clip = instance.partFour;
				instance.source.Play();
			}
		} else {
			Debug.LogError("Unavailable MusicPlayer component");
		}
	}
}

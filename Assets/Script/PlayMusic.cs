using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayMusic : MonoBehaviour 
{

	public AudioSource sound;
	public Slider slider;

	private AudioSource teste;
	void Start() 
	{
//		slider.value = 0.5f;

	}

	public void setVolume(){
		Debug.Log ("Svalue = " + sound.GetComponent<AudioSource> ().volume);
		sound.volume = slider.value;
	
	}
	void Update ()
	{

	}

}
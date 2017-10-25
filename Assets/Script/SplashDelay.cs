using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashDelay : MonoBehaviour {

	public GameObject back;
	public GameObject bloco;
	private float scale;
	// Use this for initialization
	void Start () {
		scale = 0f;
		bloco.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		back.GetComponent<Transform> ().localScale = new Vector2(scale,scale);
		scale += Time.deltaTime;
		if (scale >= 1.25f) {
			scale = 1.25f;
			bloco.SetActive (true);
		}

		
		Debug.Log (scale);

	}
}

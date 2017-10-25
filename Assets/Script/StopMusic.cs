using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Destroy (GameObject.Find ("Som"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

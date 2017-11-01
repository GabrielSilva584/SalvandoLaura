using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResizeBackground : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var rt = GetComponent<RectTransform>();
		if (rt == null) return;

		//rt.sizeDelta =  new Vector2 (Screen.width, Screen.height);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageScene0 : MonoBehaviour {

	public GameObject fala1;
	public GameObject fala2;
	public GameObject fala3;

	public float _delay = 5.0f;

	public IEnumerator Start()
	{
		fala1.SetActive (true);
		fala2.SetActive (false);
		fala3.SetActive (false);
		yield return new WaitForSeconds(_delay);
		fala1.SetActive (false);
		fala2.SetActive (true);
		fala3.SetActive (false);

		_delay += 2.0f; 
		yield return new WaitForSeconds(_delay);
		fala1.SetActive (false);
		fala2.SetActive (false);
		fala3.SetActive (true);
	}
}

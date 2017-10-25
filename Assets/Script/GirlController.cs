using UnityEngine;
using System.Collections;

public class GirlController : MonoBehaviour {

	public float speed;
	private float x;
	private float y;

	// Use this for initialization
	void Start () {
		Debug.Log ("Carro");

	}

	// Update is called once per frame
	void Update () {
		x = transform.position.x;
		y = transform.position.y;

		x += speed * Time.deltaTime;
		y += speed * Time.deltaTime;

		transform.position = new Vector3 (x, y, transform.position.z);


	}

}

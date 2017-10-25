using UnityEngine;
using System.Collections;

public class CarroPlayer : MonoBehaviour {


	private		float 	x;
	private 	float y;
	private float coef = 2f;
	public		float	 		velocidade;

	public GameObject carro;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		x = transform.position.x;
		y = transform.position.y;
		coef = (coef - x) / 1.8f;
		x -= velocidade * Time.deltaTime;
		y -= velocidade * Time.deltaTime;
		//y = y - 0.1f;
		/*if (y  < -1.78f) {
			y = -0.77f;
			x = 0.08f;
		}*/
		if (coef < 1.3f)
			coef = 1.8f;
		else if (coef < 2.0f)
			coef = 2.4f;
		else if (coef < 3.0f)
			coef = 2.8f;
		carro.GetComponent<Transform> ().localScale = new Vector2 (coef,coef);
		transform.position = new Vector3 (x, y, transform.position.z);
	
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class NameTextManager : MonoBehaviour {

	public InputField name;

	public string _nextScene;

	public void Start(){
		
	}

	public void Carregar_Cena(){
		PlayerPrefs.SetString ("nome_jogador", name.text.ToString ());
		SceneManager.LoadScene (_nextScene);
	}
	public void GetAndSetTextName(){
		if (name.text != "") {
			Carregar_Cena ();
		}
	}
	public void Update() {
		if(name.text != "" && Input.GetKey(KeyCode.Return)) {
			Carregar_Cena ();
		}
	}
}

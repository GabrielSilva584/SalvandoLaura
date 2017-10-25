using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Button_Manager : MonoBehaviour {
	
	public string cenario = "Cenario1";
	public void NewGameButtn(string gameLevel){
		//Verificar se o usuario ja se identificou na pagina, no caso afirmativo, ele nao precisaria fazer mais o login, Senao ele loga de novo.
		if (gameLevel == "Identification") {
			string nome = PlayerPrefs.GetString ("nome_jogador", "_____");
			if (nome != "_____")
			SceneManager.LoadScene ("Cenario0");
			else
				SceneManager.LoadScene (gameLevel);
		} else {
			SceneManager.LoadScene (gameLevel);
		} 
	}

	public void ExitGameButtn(){
		//Setar todos os PlayersPrefs
		PlayerPrefs.SetString ("nome_jogador", "_____");

		Application.Quit ();
	}

	public void LoadGameButtn(){
		//A programar
	}
}

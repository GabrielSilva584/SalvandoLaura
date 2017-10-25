using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Animated_Text : MonoBehaviour {

	public Text textArea;

	public string[] falas;
	public Text[] message;
	public float speed;
	public GameObject fundo;
	public GameObject objeto;
	public GameObject pular;
	public GameObject voltar;
	public GameObject nomeAnjo;
	public GameObject nomeDiabo;
	public Text nomeJogador;

	private Button teste;
	private int falasIndex;
	private int caracterIndex;
	private string nome;
	//private int i; //controlar o fundo i = 0 CEU e i = 1 inferno

	// Use this for initialization
	void Start () {
		nome = PlayerPrefs.GetString ("nome_jogador");
		//message [0].text = nome + "rs" + message [1].color;
		//nome = "<color=blue>" + nome + "</color>";
		//nomeJogador.text = "Bom dia";
		//Debug.Log (nomeJogador.text);
		//nomeJogador.text = ;
		//nomeJogador.color = Color.black;
		speed = 0.05f;
		//i = 0; //comeca com a seta enable
		GameObject.Find ("Background").GetComponent<Image> ().enabled = false;
		StartCoroutine (DisplayTimer());
		falas [0] = "Ora, ora, pobre menininha... essa é Laura, ela estava atrasada pra sua  prova de matemática financeira e saiu correndo de casa com sua bicicleta, mas  como vocês podem ver... Laura acabou sofrendo um acid...";
		falas [8] = "E quem vai responder essas questões? Laura está impossibilitada!  Ahhhh... Tive uma ideia. Ei... É, tu mesmo *"  + nome + "* ! Você será responsável por salvar  Laura.";
		falas [9] = "Ahh... Então temos um novo indivíduo na história. Vou explicar para você, *"+ nome +"*, como funciona o duelo. Será simples: vamos apresentar várias questões sobre  matemática financeira e se você tiver mais erros do que acertos, Laura não  sobreviverá.";
		falas [12] = "Então vamos começar logo. Conto com a sua ajuda, *" + nome + "*!";
	}
		
	IEnumerator DisplayTimer(){
		while (true) {
			yield return new WaitForSeconds (speed);
			if (caracterIndex > falas [falasIndex].Length) {
				
				continue;

			}

			//Quando acabar as perguntas muda de quadro
			if (falasIndex == falas.Length - 1) {
				GameObject.Find ("Background").GetComponent<Image> ().enabled = true;
				SceneManager.LoadScene ("Completo");
				break;

			}

			if ((falasIndex % 2) == 0) {
				fundo.SetActive (true);
				objeto.SetActive (false);
			}
			else {
				fundo.SetActive (false);
				objeto.SetActive (true);
			}
			textArea.text = falas [falasIndex].Substring (0, caracterIndex);
			caracterIndex++;
			//i++;
		}

	}
		
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
			
			if (caracterIndex < falas [falasIndex].Length) {
				caracterIndex = falas [falasIndex].Length;

			} else if (falasIndex < falas.Length) {
				falasIndex++;
				caracterIndex = 0;

			} 

			voltar.SetActive (true);
			//teste.enabled = true;

		}
		if ((falasIndex % 2) == 0) {
			if (falasIndex == 0) {
				voltar.GetComponent<Image> ().enabled = false;
				voltar.SetActive (false);

			} else
				voltar.SetActive (true);
			//teste.GetComponent<Image> ().enabled = false;
			//teste.enabled = false;

			nomeAnjo.SetActive (true);
			nomeDiabo.SetActive (false);

		} else {
			voltar.GetComponent<Image> ().enabled = true;
			//teste.GetComponent<Image> ().enabled = true;
			//teste.enabled = true;
			voltar.SetActive (true);
			nomeAnjo.SetActive (false);
			nomeDiabo.SetActive (true);
		}
			

	}

	public void Onclick(){
		if (pular) {
			SceneManager.LoadScene ("Completo");
		}
	}
	public void Voltar(){
		if (voltar) {
			voltar.SetActive (false);
			//ver condicao quando falsIndex == 0 para anular o loop de imagens nas falas
			falasIndex--;

			Debug.Log (falasIndex);
			caracterIndex = 0;
		}
	}




}

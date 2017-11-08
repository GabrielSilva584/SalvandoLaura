using UnityEngine;
using System.Collections;
using LitJson;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections.Generic;

public class Perguntas : MonoBehaviour {

	public string filePath;
	public string jsonString;
	public JsonData perguntaData;
	public int numPergunta = 0;
	public int numPergunta2 = 0;
	public GameObject resposta;
	public bool proximaPergunta;
	public bool clickQuadro;
	public int score;
	public Font myFont;
	public GameObject background;
	public Text tempo;

	public List<int> PerguntasFeitas;

	//Parte dos audios
	//
	public AudioSource AudioSource;
	public AudioSource AudioSource1;
	public AudioSource AudioSource2;

	// Use this for initialization
	void Start ()
	{
		// Audio Source responsavel por emitir os sons
		AudioSource.Play();
		AudioSource2.Stop();
		AudioSource1.Stop ();
		PerguntasFeitas = new List<int> ();

	}
	public void SoalBegin(string jsonName){
		score = 0;
		proximaPergunta = true;
		filePath = System.IO.Path.Combine(Application.streamingAssetsPath, jsonName + ".json");
		StartCoroutine ("Json");
		
	}
	
	IEnumerator Json(){
		if (filePath.Contains ("://")) {
			WWW www = new WWW (filePath);
			yield return www;
			jsonString = www.text;
			perguntaData = JsonMapper.ToObject (jsonString);
			numPergunta = getRandPergunta();
			OnClick ();
		} else {
			jsonString = System.IO.File.ReadAllText(filePath);
			perguntaData = JsonMapper.ToObject (jsonString);
			numPergunta = getRandPergunta();
			OnClick ();
		}
	}
	
	public void OnClick(){
		if (numPergunta2 >= int.Parse(perguntaData ["perguntas"].ToString())) {	
			
			MenuManager menuResult = GameObject.Find("Canvas").GetComponent<MenuManager>();
			if(score == perguntaData["data"].Count && PlayerPrefs.GetInt ("question") == 1){//10
				//GameObject.Find("Rank").GetComponent<Text>().text = "Muito Bem";
				GameObject.Find ("Perdeu").GetComponent<Image> ().enabled = false;
				GameObject.Find ("Ganhou").GetComponent<Image> ().enabled = true;
				GameObject.Find ("estrela1on").GetComponent<Image> ().enabled = true;
				GameObject.Find ("estrela2on").GetComponent<Image> ().enabled = true;
				GameObject.Find ("estrela3on").GetComponent<Image> ().enabled = true;
				GameObject.Find ("Diabo").GetComponent<Image> ().enabled = false;
				//fundo ceu
				background.SetActive(false);


				//Tocar os audios
				AudioSource.Stop();
				AudioSource1.Play();
				AudioSource2.Stop ();

			}else
				if(score > perguntaData["data"].Count*1/2 && PlayerPrefs.GetInt ("question") == 1){
				//GameObject.Find("Rank").GetComponent<Text>().text = "Que Otimo";
				GameObject.Find ("Perdeu").GetComponent<Image> ().enabled = false;
				GameObject.Find ("Ganhou").GetComponent<Image> ().enabled = true;
				GameObject.Find ("estrela1on").GetComponent<Image> ().enabled = true;
				GameObject.Find ("estrela2on").GetComponent<Image> ().enabled = true;
				GameObject.Find ("estrela3on").GetComponent<Image> ().enabled = false;
				GameObject.Find ("Diabo").GetComponent<Image> ().enabled = false;
				//fundo ceu
				background.SetActive(false);

				//Tocar os audios
				AudioSource.Stop();
				AudioSource1.Play();
				AudioSource2.Stop ();

			}else
					if(score <= perguntaData["data"].Count*1/2 && PlayerPrefs.GetInt ("question") == 1){
				//GameObject.Find("Rank").GetComponent<Text>().text = "Poxa";
				GameObject.Find ("Perdeu").GetComponent<Image> ().enabled = true;
				GameObject.Find ("Ganhou").GetComponent<Image> ().enabled = false;
				GameObject.Find ("estrela1on").GetComponent<Image> ().enabled = false;
				GameObject.Find ("estrela2on").GetComponent<Image> ().enabled = false;
				GameObject.Find ("estrela3on").GetComponent<Image> ().enabled = false;
				GameObject.Find ("Anjo").GetComponent<Image> ().enabled = false;
				//fundo inferno
				background.SetActive(true);
				
				//Tocar os audios
				AudioSource.Stop();
				AudioSource2.Play();
				AudioSource1.Stop ();

			}

			if (PlayerPrefs.GetInt ("question") == 0) {//Quando estou na fase Teste
				Debug.Log ("T1 = " + PlayerPrefs.GetInt ("notaT"));

				//Aqui se da primeira vez conseguiu 8 e o nivel for desbloqueado, se ele jogar o nivel 0 de novo so vai ser registrado o ultimo valor tipo SUB do MAL
				PlayerPrefs.SetInt ("notaT", score);
				Debug.Log ("T2 = " + PlayerPrefs.GetInt ("notaT"));
				menuResult.ShowMenu (GameObject.Find ("Result_Teste").GetComponent<Menu> ());
				if (score < 7) {
					GameObject.Find ("Msg").GetComponent<Text> ().text = "Poxa,tente novamente! Consiga uma nota alta para desbloqueiar o nível ...";
					GameObject.Find ("Score").GetComponent<Text> ().text = score.ToString () + "/" + perguntaData ["data"].Count;
				} else {
					GameObject.Find ("Msg").GetComponent<Text> ().text = "Parabéns, você desbloqueiou o nível ...";
					//Esse codigo permite que uma vez que o usuario desbloqueiou o proximo nivel, nunca mais vai ser bloqueado de novo até mesmo que consiga uma nota inferior a 7
					/*if(PlayerPrefs.GetInt("Total") < score)
					PlayerPrefs.SetInt ("Total", score);
					*/
				}
				GameObject.Find ("Pont").GetComponent<Text> ().text = score.ToString () + "/" + perguntaData ["data"].Count;
			} else if (PlayerPrefs.GetInt ("question") == 1) {
				menuResult.ShowMenu (GameObject.Find ("Result").GetComponent<Menu> ());
			}

			GameObject.Find("Score").GetComponent<Text>().text = score.ToString() + "/" + perguntaData["data"].Count;

		}
				
			if (proximaPergunta) {
				GameObject[] jawabanDestroy = GameObject.FindGameObjectsWithTag ("Jawaban");
				if (jawabanDestroy != null) {
					for (int x=0; x<jawabanDestroy.Length; x++) {
						DestroyImmediate (jawabanDestroy [x]);
					}
				}
		
			GameObject.Find ("Perguntas/Panel/PerguntasQ/Pergunta").GetComponentInChildren<Text> ().text = perguntaData ["data"] [numPergunta] ["pergunta"].ToString ();
				
				//Alternativas
			for (int i=0; i<perguntaData["data"][numPergunta]["resposta"].Count; i++) {
			
				GameObject opcaoResposta = Instantiate (resposta);
					opcaoResposta.GetComponentInChildren<Text> ().text = perguntaData ["data"] [numPergunta] ["resposta"] [i].ToString ();
				Transform respostaTeste = GameObject.Find ("QuadroOpcao").GetComponent<Transform> ();
					

				var colors = opcaoResposta.GetComponent<Button> ();
				colors.GetComponentInChildren<Text> ().font = myFont;
				colors.GetComponentInChildren<Text> ().fontSize = 30;
				colors.GetComponentInChildren<Text> ().color = Color.black;
				colors.GetComponentInChildren<Image> ().color = Color.grey;
					opcaoResposta.transform.SetParent (respostaTeste);


					string x = i.ToString ();

					if (i == 0) {
						opcaoResposta.name = "RespostaCerta";
						opcaoResposta.GetComponent<Button> ().onClick.AddListener (() => Jawaban ("0"));
					} else {
						opcaoResposta.name = "RespostaErrada" + x;
						opcaoResposta.GetComponent<Button> ().onClick.AddListener (() => Jawaban (x));
					}
					opcaoResposta.transform.SetSiblingIndex (Random.Range (0, 3));
				}
		
				numPergunta = getRandPergunta ();
				numPergunta2++;
				proximaPergunta = false;
				clickQuadro = true;
				StartCoroutine ("Timer");
			}

	}
	public void Jawaban(string x){
		if (clickQuadro) {
			if (x == "0") {
				score++;
				GameObject.Find ("RespostaCerta").GetComponent<Button> ().image.color = Color.green;
				GameObject.Find("Image ("+numPergunta2+")").GetComponent<Image>().color = Color.green;
				Debug.Log ("Acertou");
			} else {
				GameObject.Find ("RespostaErrada" + x).GetComponent<Button> ().image.color = Color.red;
				GameObject.Find ("RespostaCerta").GetComponent<Button> ().image.color = Color.green;
				GameObject.Find("Image ("+numPergunta2+")").GetComponent<Image>().color = Color.red;
				Debug.Log ("Errou");
			}
		}
		proximaPergunta = true;
		clickQuadro = false;
		
	}
	IEnumerator Timer(){
		Image time = GameObject.Find ("Timer").GetComponent<Image> ();
		Text tempo = GameObject.Find ("Tempo").GetComponent<Text> ();
		time.fillAmount = 1;
		float timeToWait;

		//timeToWait = 60;
		timeToWait =  float.Parse(perguntaData ["data"][numPergunta]["tempo"].ToString());
		tempo.text = timeToWait.ToString ();
		 
		float incrementToRemove = 1;
		float x = time.fillAmount / timeToWait * incrementToRemove;

		while(timeToWait>0){
			yield return new WaitForSeconds(incrementToRemove);

			if(!proximaPergunta){
				time.fillAmount -=x;
				timeToWait-=incrementToRemove;
				tempo.text = timeToWait.ToString ();
			}else{
				timeToWait = 0;
			}

		}
		if (time.fillAmount <= 0.1f) {
			for(int i=1; i<4; i++){
				
				GameObject.Find ("RespostaErrada" + i).GetComponent<Button> ().image.color = Color.red;
			}
			GameObject.Find ("RespostaCerta").GetComponent<Button> ().image.color = Color.green;
			GameObject.Find("Image ("+numPergunta+")").GetComponent<Image>().color = Color.red;
			clickQuadro = false;
			proximaPergunta = true;
		}

	}

	int getRandPergunta(){
		int i = 1;
		int novaPergunta = 0;

		if (perguntaData ["data"].Count == PerguntasFeitas.Count)
			return perguntaData ["data"].Count;
		
		while (i == 1) {
			i = 0;
			novaPergunta = Random.Range (0, perguntaData ["data"].Count);

			foreach (int pergunta in PerguntasFeitas) {
				if (novaPergunta == pergunta)
					i = 1;
			}
		}

		Debug.Log ("novaPergunta =" + novaPergunta);
		PerguntasFeitas.Add (novaPergunta);
		return novaPergunta;
	}
}

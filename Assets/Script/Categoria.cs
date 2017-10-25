using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.UI;

public class Categoria : MonoBehaviour {

	public GameObject CategoPref;
	public MenuManager menu;
	public Perguntas pergunta;
	public Font myFont;

	private RectTransform rect;
	private int test ;
	private int i;
	void Start () {
		
		rect = gameObject.GetComponent<RectTransform> ();
		//Total = 
		test = PlayerPrefs.GetInt ("notaT",0);
		i = 0;
		//Teste inferior a 7 ele vai na parte da preparaçao (incluinto a canva Result_Teste)e o jogo esta desativado até ele conseguir uma nota maior do que 7

		string filePath = Application.streamingAssetsPath + "/";
		//GameObject.Find ("Teste").GetComponent<Text> ().text = filePath;
		//DirectoryInfo dir = new DirectoryInfo (filePath);
		carregar (test);
	}

	public void carregar(int teste){
	
		TextAsset[] files = Resources.LoadAll<TextAsset> ("");

		foreach (TextAsset file in files) {
			Debug.Log (files.Length);
			GameObject kat = Instantiate (CategoPref) as GameObject;
			kat.name = Path.GetFileNameWithoutExtension (file.name).ToString ();
			kat.transform.SetParent (GameObject.Find ("Categoria/Panel/Scroll/KategoriC").GetComponent<Transform> ());
			kat.GetComponentInChildren<Text> ().text = kat.name;
			Debug.Log ("Teste = " + test);
			//i = 1 (Vamos la)na sequencia do arquivo Streaming Asset, a ordem começa com i= 0 no nosso caso é preparaçao
			//No inicio usei kat.name == "Vamos-la"
			if (i == 1) {
				
				var colo = kat.GetComponent<Button> ();
				colo.GetComponentInChildren<Text> ().font = myFont;
				colo.GetComponentInChildren<Text> ().fontSize = 15;
				if (teste < 7) {
					kat.GetComponent<Button> ().interactable = false;
				}
				else
					kat.GetComponent<Button> ().interactable = true;
			}
				
			var colors =  kat.GetComponent<Button> ();
			colors.GetComponentInChildren<Text> ().font = myFont;
			colors.GetComponentInChildren<Text> ().fontSize = 40;
			string katName = kat.name;
			kat.GetComponent<Button>().onClick.AddListener(() => OnClick(katName));
			kat.GetComponent<Button>().onClick.AddListener(() => menu.ShowMenu(GameObject.Find("Canvas/Perguntas").GetComponent<Menu>()));
			i++;
		}

		rect.sizeDelta = new Vector2 (rect.sizeDelta.x, (rect.sizeDelta.y/6)* files.Length);
	
	}

	public void OnClick(string categoria){
		pergunta.SoalBegin (categoria);
		if (categoria == "Preparacao") {
			PlayerPrefs.SetInt ("question", 0);
		} else if (categoria == "Vamos-la") {
			PlayerPrefs.SetInt ("question", 1);
		}
		Debug.Log ("Categoria = " + categoria);

	}

}

using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	private Animator _animator;
	private CanvasGroup _canvasGroup;

	public void Start(){
		//Ao initializar o jogo, é atribuido a nota do teste o valor 0, para impossibilitar a escolha do nivel Vamos-la. ver script Perguntas.cs line 124
		PlayerPrefs.SetInt ("notaT", 0);
	}
	public bool IsOpen{

		get { return _animator.GetBool ("IsOpen");}
		set { _animator.SetBool ("IsOpen", value);}

	}

	public void Awake(){

		_animator = GetComponent<Animator> ();
		_canvasGroup = GetComponent<CanvasGroup> ();

		var rect = GetComponent<RectTransform> ();
		rect.offsetMax = rect.offsetMin = new Vector2 (0, 0);


	}
	public void Update(){

		if (!_animator.GetCurrentAnimatorStateInfo (0).IsName ("Open")) {
			_canvasGroup.blocksRaycasts = _canvasGroup.interactable = false;
		} else {
			_canvasGroup.blocksRaycasts = _canvasGroup.interactable = true;

		}

	}
}
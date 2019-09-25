using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class AlphabetManager : MonoBehaviour {
	Animator anim;
	public static AlphabetManager instance;
	public GameObject UIManager;
	public GameObject[] alphabetNote_T1;
	public TMP_Text scoreLeft;
	public TMP_Text scoreRight;
	public Slider leftSlider;
	public Slider rightSlider;
	int _scoreLeft;
	int _scoreRight;

	int _rightSliderValue=0;
	private int _currentValue;

	int _leftSliderValue=0;
	private int _leftCurrentValue;

	// Use this for initialization
	void Start () {
		if (instance == null) {
			instance = this;
		}
		_scoreLeft = 0;
		_scoreRight = 0;
		_currentValue = _rightSliderValue;
		_leftCurrentValue = _leftSliderValue;

        Application.targetFrameRate = 60;
	}	
	// Update is called once per frame
	void Update () {
		scoreLeft.text = _scoreLeft.ToString ()+" %";
		scoreRight.text = _scoreRight.ToString ()+" %";
	}
	public void CheckAlphabet(int a)
	{
		for (int i = 0; i < alphabetNote_T1.Length; i++) {
			if (i == a) {
				if (a >= 0 && a <= 25) {
					alphabetNote_T1 [i].GetComponent<Image> ().color = Color.green;
					_scoreLeft += 1;
					_leftCurrentValue += 1;	
					alphabetNote_T1 [i].GetComponent<Animator> ().SetTrigger("A");
				}
				else if(a>=26 && a<=51){
					alphabetNote_T1 [i].GetComponent<Image> ().color = Color.red;
					_scoreRight += 1;
					_currentValue += 1;
					alphabetNote_T1 [i].GetComponent<Animator> ().SetTrigger("A");
				}
			} 
		}
		rightSlider.value =_currentValue;
		leftSlider.value = _leftCurrentValue;
	}
	public void Refreshbtn(int lvl)
	{
		SceneManager.LoadScene (0);
	}
	public void OpenCameraMode()
	{
		UIManager.GetComponent<Image> ().color = new Color32 (254,205,120,0);
	}
}

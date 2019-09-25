using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ManuController : MonoBehaviour {
	public GameObject lodingScene;
	public Slider lodingSlider;
	AsyncOperation async;
	// Use this for initialization
	public void LoadingScenesBar (int lvl) {
		StartCoroutine (LodingScenes (lvl));
	}
	IEnumerator LodingScenes(int lvl){
		lodingScene.SetActive (true);
		async = SceneManager.LoadSceneAsync (lvl);
		async.allowSceneActivation = false;

		while(async.isDone == false){
			lodingSlider.value = async.progress;
			if (async.progress == 0.9f) {
				lodingSlider.value = 1f;
				async.allowSceneActivation = true;
			}
			yield return null;
		}
	}
	// Update is called once per frame
	void Update () {
		
	}

}

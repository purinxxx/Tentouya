using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class sceneChange : MonoBehaviour {

	private float time = 60+3;
	public static bool teisi = false;
	public GameObject posemenu;

	public void pose(){
		teisi = true;
		iTween.Pause();
		GameObject.Find("poseCanvas").GetComponent<Canvas>().enabled = true;
	}
	public void saikai(){
		teisi = false;
		iTween.Resume();
		transform.root.gameObject.GetComponent<Canvas>().enabled = false;
	}
	public void gamestart()
	{
		teisi = false;
		iTween.tweens.Clear ();
		SceneManager.LoadScene("stage1");
	}
	public void menu()
	{
		teisi = false;
		iTween.tweens.Clear ();
		SceneManager.LoadScene("menu");
	}
	public void story()
	{
		SceneManager.LoadScene("story");
	}

	// Use this for initialization
	private void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(!teisi) time -= Time.deltaTime;

        if (time < 0) 
        {
			SceneManager.LoadScene("result");
        }
		
	}
}

//リトライ時おitweenのエラー　https://kido0617.github.io/unity/2014-09-27-itween-stop/

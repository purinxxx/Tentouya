using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class sceneChange : MonoBehaviour {

	private float time = 60+3;


	// Use this for initialization
	private void Start () {
     
	}
	
	// Update is called once per frame
	void Update () {
        time -= Time.deltaTime;

        if (time < 0) 
        {
            StartCoroutine("MoveScene");
        }
		
	}
    public void MoveScene()
    {
    
        SceneManager.LoadScene("result");
    }
}

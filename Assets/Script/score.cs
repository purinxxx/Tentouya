using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class score : MonoBehaviour {

	public static float point;
	public static float max;
	public Text ScoreText;
	public GameObject dark;
	public GameObject light;

	// Use this for initialization
	void Start () {
		if(SceneManager.GetActiveScene().name == "test"){
			point = 0;
			max = 68;
		} else if(SceneManager.GetActiveScene().name == "result"){
			dark.SetActive (false);
			light.SetActive (false);
			Debug.Log (point/max*100);
			if (point/max*100 > 50) {
				light.SetActive (true);
			} else {
				dark.SetActive (true);
			}
		}
    }
	
	// Update is called once per frame
	void Update () {
		if(SceneManager.GetActiveScene().name == "result"){
			ScoreText.text = point.ToString() + " / " + max.ToString();

		} else if(SceneManager.GetActiveScene().name == "test"){
			ScoreText.text = "SCORE : " + point.ToString();

		}
    }
}

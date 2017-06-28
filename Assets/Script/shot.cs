using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		//Debug.Log(power);

		Debug.Log(other.gameObject.name);

		if (sceneChange.teisi==false) {
			if (other.GetComponent<SpriteRenderer> ().color.a == 0f) {
				other.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0.1f); //スコアが二重に加算されるのを防ぐ！！
				score.point++;
				//other.gameObject.GetComponent<Renderer>().enabled = true;
				StartCoroutine (fadein (other.gameObject));
			
			}
		}
	}

	private IEnumerator fadein(GameObject obj) {
		for (float alpha = 0.1f; alpha < 1.1f; alpha += 0.05f) {
			obj.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, alpha);
			yield return null;
		}
	}

}

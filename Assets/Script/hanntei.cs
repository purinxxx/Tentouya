using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class hanntei : MonoBehaviour {

	public static float power;
    public float timeOut;
    public Text scoreText;
    private float timeElapsed;
	private Animator animator;
	GameObject bar;
	RectTransform barrect;


    // Use this for initialization
    void Start() {
		power = 100f;
		animator = GetComponent<Animator>();
		bar = GameObject.Find ("bar");
		barrect = bar.GetComponent<RectTransform>();
		StartCoroutine ("GuageCharge");
    }

    // Update is called once per fr other){ame
    void Update()
    {
        
        //timeElapsed += Time.deltaTime;
       

        // if (timeElapsed >= timeOut){
        //GuageCharge();

        //timeElapsed = 0.0f; }

        scoreText.text = power.ToString();

		if (Input.GetMouseButtonDown (0)) {
			if (power > 10) {
				power -= 10;
				animator.Play("shot");
			}
		}


		float tmp = 1 - power / 100;
		tmp = 257 * tmp;
		tmp = -13 - tmp;
		Vector3 pos = barrect.localPosition;
		pos.x = tmp;
		barrect.localPosition = pos;
    }
    
    
	void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log(power);

		Debug.Log(other.gameObject.name);

        if (Input.GetMouseButtonDown(0)) {
			if(power > 10) {
				if (other.GetComponent<SpriteRenderer> ().color.a == 0f) {
					other.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, 0.1f); //スコアが二重に加算されるのを防ぐ！！
					score.point++;
					//other.gameObject.GetComponent<Renderer>().enabled = true;
					StartCoroutine (fadein (other.gameObject));
				}
            }
        }
    }

    /*void GuageCharge()
    {
        if(power < 100)
        {
            power += 0.25f;
        }
    }*/

	private IEnumerator fadein(GameObject obj) {
		for (float alpha = 0.1f; alpha < 1.0f; alpha += 0.1f) {
			obj.GetComponent<SpriteRenderer> ().color = new Color (1, 1, 1, alpha);
			yield return null;
		}

		/*処理を軽くするために光った後のcolliderを無効化
		if(obj.GetComponent<BoxCollider2D>()!=null) obj.GetComponent<BoxCollider2D> ().enabled = false;
		if(obj.GetComponent<PolygonCollider2D>()!=null) obj.GetComponent<PolygonCollider2D> ().enabled = false;
		if(obj.GetComponent<EdgeCollider2D>()!=null) obj.GetComponent<EdgeCollider2D> ().enabled = false;
		if(obj.GetComponent<CapsuleCollider2D>()!=null) obj.GetComponent<CapsuleCollider2D> ().enabled = false;
		*/
	}
	private IEnumerator GuageCharge() {
		while(true) {
			if(power < 100) power += 0.25f;
			yield return new WaitForSeconds (0.01f);
		}
	}
}

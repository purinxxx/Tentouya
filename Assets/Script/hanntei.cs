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
	public GameObject bullet;


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

		if (Input.GetMouseButtonDown(0) && sceneChange.teisi==false) {
			if (power > 10) {
				power -= 10;
				animator.Play("shot");
				bullet.transform.position=this.transform.position;
			}
		}


		float tmp = 1 - power / 100;
		tmp = 257 * tmp;
		tmp = -13 - tmp;
		Vector3 pos = barrect.localPosition;
		pos.x = tmp;
		barrect.localPosition = pos;
    }
    
    

	private IEnumerator GuageCharge() {
		while(true) {
			if(power < 100 && sceneChange.teisi==false) power += 0.35f;
			yield return new WaitForSeconds (0.01f);
		}
	}
}

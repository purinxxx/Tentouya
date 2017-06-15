using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onscreencollider : MonoBehaviour {

	bool _isRendered = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (_isRendered) {
			//処理を軽くするために光った後のcolliderを無効化
			if (GetComponent<BoxCollider2D> () != null)
				GetComponent<BoxCollider2D> ().enabled = true;
			if (GetComponent<PolygonCollider2D> () != null)
				GetComponent<PolygonCollider2D> ().enabled = true;
			if (GetComponent<EdgeCollider2D> () != null)
				GetComponent<EdgeCollider2D> ().enabled = true;
			if (GetComponent<CapsuleCollider2D> () != null)
				GetComponent<CapsuleCollider2D> ().enabled = true;
		} else {
			if (GetComponent<BoxCollider2D> () != null)
				GetComponent<BoxCollider2D> ().enabled = false;
			if (GetComponent<PolygonCollider2D> () != null)
				GetComponent<PolygonCollider2D> ().enabled = false;
			if (GetComponent<EdgeCollider2D> () != null)
				GetComponent<EdgeCollider2D> ().enabled = false;
			if (GetComponent<CapsuleCollider2D> () != null)
				GetComponent<CapsuleCollider2D> ().enabled = false;
		}
		_isRendered = false;
	}

	void OnWillRenderObject() {
		_isRendered = true;
	}
}

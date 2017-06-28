using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour {

	public GameObject posemenu;

	// Use this for initialization
	void Start () {
		posemenu.GetComponent<Canvas>().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

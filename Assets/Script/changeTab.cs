using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeTab : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	public void collection(){
		tabmanager.collectionTab.SetActive (true);
		tabmanager.stageTab.SetActive (false);
	}
	public void stage(){
		tabmanager.stageTab.SetActive (true);
		tabmanager.collectionTab.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

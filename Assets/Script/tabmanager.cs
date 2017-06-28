using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tabmanager : MonoBehaviour {
	public static GameObject stageTab;
	public static GameObject collectionTab;

	// Use this for initialization
	void Start () {
		stageTab = GameObject.Find ("stageselectPanel");
		collectionTab = GameObject.Find ("collectionPanel");
		collectionTab.SetActive (false);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

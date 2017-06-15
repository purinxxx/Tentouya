using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScriptOnSpline : MonoBehaviour {



    public int time = 50;
    public string PathName = "Path1";
    // Use this for initialization
    void Start()
    {
        iTween.MoveTo(this.gameObject, iTween.Hash("path", iTweenPath.GetPath(PathName), "time", time,"EaseType", iTween.EaseType.linear));
    }

    // Update is called once per frame
    void Update () {
		
	}
}

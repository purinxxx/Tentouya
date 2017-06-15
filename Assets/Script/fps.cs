using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fps : MonoBehaviour {

	int frameCount;
	float prevTime;
	public Text fpstext;

	void Start()
	{
		frameCount = 0;
		prevTime = 0.0f;
	}

	void Update()
	{
		++frameCount;
		float time = Time.realtimeSinceStartup - prevTime;

		if (time >= 0.5f) {
			fpstext.text = "fps : " + (frameCount / time).ToString();

			frameCount = 0;
			prevTime = Time.realtimeSinceStartup;
		}
	}
}

﻿using UnityEngine;
using System.Collections;

namespace WordTree
{
	public class PulseBehavior : MonoBehaviour {

		public void StartPulsing (GameObject go)
		{
			float scaleUpBy = 1.2f; 
			float time = Random.Range (.8f,1.0f);

			if (go.name == "Play" || go.name == "Learn")
				scaleUpBy = 1.1f;
			
			LeanTween.scale(go, new Vector3(go.transform.localScale.x * scaleUpBy, go.transform.localScale.y * scaleUpBy, 
			                                go.transform.localScale.z * scaleUpBy), time)
				.setEase(LeanTweenType.easeOutSine).setLoopPingPong();
		}
		
		public void StopPulsing (GameObject go)
		{
			LeanTween.cancel (go);
			if (go.tag == "MovableLetter")
				go.transform.localScale = new Vector3 (.3f, .3f, 1);
		}

	}
}

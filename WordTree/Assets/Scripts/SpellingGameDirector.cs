﻿using UnityEngine;
using System.Collections;

namespace WordTree
{
	public class SpellingGameDirector : MonoBehaviour {

		//public static int wordIndex = 0;

		void Start () {

			LoadSpellingGameWord (ProgressManager.currentWord);
			//LoadSpellingGame (ProgressManager.currentLevel);

			GameObject[] buttons = GameObject.FindGameObjectsWithTag ("Button");
			foreach (GameObject button in buttons)
				button.AddComponent<GestureManager> ().AddAndSubscribeToGestures (button);

			GameObject word = GameObject.FindGameObjectWithTag ("WordObject");
			word.GetComponent<GestureManager> ().DisableGestures (word);

			GameObject[] tar = GameObject.FindGameObjectsWithTag("TargetBlank");
			GameObject audioManager = GameObject.Find ("AudioManager");
			audioManager.GetComponent<AudioManager>().SpellOutWord(tar);

			GameObject[] mov = GameObject.FindGameObjectsWithTag ("MovableLetter");
			foreach (GameObject go in mov) {
				go.GetComponent<PulseBehavior> ().StartPulsing (go, (tar.Length+1) * AudioManager.clipLength);
			}

		}

		/*
		public void LoadNextWord(float delayTime)
		{
			StartCoroutine (loadNextWord(delayTime));
		}

		IEnumerator loadNextWord(float delayTime)
		{
			yield return new WaitForSeconds (delayTime);

			wordIndex = wordIndex + 1;

			Debug.Log ("Loading next word");
			LevelProperties prop = LevelProperties.GetLevelProperties (ProgressManager.currentLevel);
			string[] words = prop.Words ();
			LoadGameWord (words[wordIndex]);

			GameObject.Find ("SoundButton").GetComponent<GestureManager>().EnableGestures(GameObject.Find ("SoundButton"));
			GameObject.Find ("HintButton").GetComponent<GestureManager>().EnableGestures(GameObject.Find ("HintButton"));


		}

		public void DestroyAll(float delayTime)
		{
			StartCoroutine (destroyAll (delayTime));
		}

		IEnumerator destroyAll(float delayTime)
		{
			yield return new WaitForSeconds (delayTime);

			GameObject[] mov = GameObject.FindGameObjectsWithTag ("MovableLetter");
			GameObject[] tar = GameObject.FindGameObjectsWithTag ("TargetBlank");
			GameObject[] hint = GameObject.FindGameObjectsWithTag ("Hint");

			foreach (GameObject go in mov)
				Destroy (go);
			foreach (GameObject go in tar)
				Destroy (go);
			foreach (GameObject go in hint)
				Destroy (go);
			Destroy (GameObject.FindGameObjectWithTag("WordObject"));
		}

		void LoadSpellingGame(string level)
		{
			LevelProperties prop = LevelProperties.GetLevelProperties (level);
			string[] words = prop.Words ();
			LoadGameWord (words [wordIndex]);

		}

		void LoadGameWord(string word)
		{
			WordProperties prop = WordProperties.GetWordProperties(word);
			string[] phonemes = prop.Phonemes ();
			float objScale = prop.ObjScale ();

			WordCreation.CreateScrambledWord (word, phonemes);
			BlankCreation.CreateBlanks(word, phonemes, "Rectangle", "TargetBlank", "SpellingGame");
			CreateWordImage (word, objScale);

			GameObject[] mov = GameObject.FindGameObjectsWithTag ("MovableLetter");
			foreach (GameObject go in mov) {
				go.GetComponent<PulseBehavior> ().StartPulsing (go);
			}

		}
		*/

		void LoadSpellingGameWord(string word)
		{
			WordProperties prop = WordProperties.GetWordProperties(word);
			string[] phonemes = prop.Phonemes ();
			float objScale = prop.ObjScale ();
			
			WordCreation.CreateScrambledWord (word, phonemes);
			BlankCreation.CreateBlanks(word, phonemes, "Rectangle", "TargetBlank", "SpellingGame");
			CreateWordImage (word, objScale);
				
		}

		void CreateWordImage(string word, float scale)
		{
			float y = 3;
			
			ObjectProperties Obj = ObjectProperties.CreateInstance (word, "WordObject", new Vector3 (0, y, 0), new Vector3 (scale, scale, 1), ProgressManager.currentLevel + "/" + word, "Words/"+word);
			ObjectProperties.InstantiateObject (Obj);
		}

		public static void SpellOutWord()
		{
			GameObject[] tar = GameObject.FindGameObjectsWithTag("TargetBlank");
			GameObject[] mov = new GameObject[tar.Length];
			for (int i=0; i<tar.Length; i++)
			{
				Vector2 posn = tar[i].transform.position;
				Collider2D[] letters = Physics2D.OverlapCircleAll(posn,1.0f,1,-1,-1);
				mov[i] = letters[0].gameObject;
			}
			GameObject audioManager = GameObject.Find ("AudioManager");
			audioManager.GetComponent<AudioManager>().SpellOutWord(mov);
		}

		public static void TryAgainAnimation()
		{	
			GameObject tryAgain = GameObject.Find ("TryAgain");
			
			LeanTween.alpha (tryAgain, 1f, .1f);
			LeanTween.alpha (tryAgain, 0f, .1f).setDelay (1f);

			LeanTween.scale (tryAgain, new Vector3 (2f,2f, 1), .7f);
			LeanTween.scale (tryAgain, new Vector3 (.5f,.5f,1), .5f).setDelay (.5f);
			
		}

		public static void CelebratoryAnimation(float delayTime)
		{	

			float time = 1f;

			GameObject go = GameObject.FindGameObjectWithTag ("WordObject");

			Debug.Log ("Spinning " + go.name + " around");
			LeanTween.rotateAround (go, Vector3.forward, 360f, time).setDelay(delayTime);
			LeanTween.scale (go,new Vector3(go.transform.localScale.x*1.3f,go.transform.localScale.y*1.3f,1),time).setDelay (delayTime);
			LeanTween.moveY (go, 2f, time).setDelay (delayTime);

			Debug.Log ("Playing clip for congrats");
			AudioSource audio = go.AddComponent<AudioSource> ();
			audio.clip = Resources.Load ("Audio/CongratsSound") as AudioClip;
			audio.PlayDelayed (delayTime);
			
			
		}


	}
}
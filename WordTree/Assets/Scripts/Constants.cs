﻿using UnityEngine;
using System.Collections;

//<summary>
//Keep list of names for tags
//</summary>
namespace WordTree
{
	public class Constants : MonoBehaviour
	{
		//<summary>
		//Names for tags of gameObjects
		//</summary>
		public static class Tags
		{
			public const string TAG_MAIN_CAMERA = "MainCamera";
			public const string TAG_LOCK = "Lock";
			public const string TAG_KID = "Kid";
			public const string TAG_GESTURE_MANAGER = "GestureManager";
			public const string TAG_BUTTON = "Button";
			public const string TAG_LEVEL_ICON = "LevelIcon";
			public const string TAG_WORD_OBJECT = "WordObject";
			public const string TAG_TARGET_LETTER = "TargetLetter";
			public const string TAG_MOVABLE_LETTER = "MovableLetter";
			public const string TAG_TARGET_BLANK = "TargetBlank";
			public const string TAG_MOVABLE_BLANK = "MovableBlank";
			public const string TAG_JAR = "Jar";
			public const string TAG_HINT = "Hint";
			public const string TAG_AUDIO_MANAGER = "AudioManager";
		}

		//<summary>
		//Names of folders
		//</summary>
		public static class fileNames
		{
			public const string phoneme = "/Phonemes/";
			public const string audio = "Audio";
			public const string word = "/Words";
			public const string incorrect = "/IncorrectSound";
			public const string congrats = "/CongratsSound";
			public const string background_music = "/BackgroundMusic";
			public const string word_tree = "/WordTree";
			public const string kid_speaking = "/KidSpeaking";
			public const string intro = "/Intro";
			public const string tumble = "/TumbleSound";
		}
	}
}

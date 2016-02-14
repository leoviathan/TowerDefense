// ------------------------------------------------------------------------------------------------------------
// 							 FinishPanel.cs
// 				 Copyright (c) 2016 Leonardo Lopes
//  	Authors: Leonardo M. Lopes <euleoo@gmail.com> - http://about.me/leonardo_lopes
// ------------------------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinishPanel : MonoBehaviour {
	public Text label;

	private Image bg;
	
	void Awake () {
		bg = GetComponent<Image>();

		GameController gameController = FindObjectOfType<GameController>();
		gameController.OnLevelFailed += HandleOnLevelFailed;
		gameController.OnLevelFinished += HandleOnLevelFinished;
	}

	void HandleOnLevelFinished ()
	{
		FadeInBG();
		label.text = "Victory!";
	}

	void HandleOnLevelFailed ()
	{
		FadeInBG();
		label.text = "Game Over!";
	}

	void FadeInBG(){
		bg.color = new Color(0f, 0f, 0f, .9f);
	}
}

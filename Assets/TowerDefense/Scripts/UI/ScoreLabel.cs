// ------------------------------------------------------------------------------------------------------------
// 							 ScoreLabel.cs
// 				 Copyright (c) 2016 Leonardo Lopes
//  	Authors: Leonardo M. Lopes <euleoo@gmail.com> - http://about.me/leonardo_lopes
// ------------------------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class ScoreLabel : MonoBehaviour {
	private GameController gameController;
	private Text label;
	
	// Use this for initialization
	void Start () {
		this.gameController = FindObjectOfType<GameController>();
		this.label = GetComponent<Text>();
		
		InvokeRepeating("UpdateLabel", 0, .2f);
	}
	
	void UpdateLabel(){
		this.label.text = string.Format("Score: {0}", this.gameController.Score);
	}
}

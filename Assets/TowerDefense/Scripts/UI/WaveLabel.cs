// ------------------------------------------------------------------------------------------------------------
// 							 WaveLabel.cs
// 				 Copyright (c) 2016 Leonardo Lopes
//  	Authors: Leonardo M. Lopes <euleoo@gmail.com> - http://about.me/leonardo_lopes
// ------------------------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class WaveLabel : MonoBehaviour {
	private WaveManager waveManager;
	private Text label;

	private int waveCount = 0;
	
	// Use this for initialization
	void Start () {
		this.waveManager = FindObjectOfType<WaveManager>();
		this.label = GetComponent<Text>();
		
		this.waveManager.OnWaveStarted += UpdateLabel;
	}

	void UpdateLabel (Wave wave)
	{
		waveCount++;
		this.label.text = string.Format("Wave {0}: ", waveCount);



		if(wave.objectsToSpawn.Length > 1){
			this.label.text += " Group of ";
		}

		this.label.text += wave.duration * wave.frequency * wave.objectsToSpawn.Length + " ";		

		int objCount = 0;
		foreach(GameObject objectToSpawn in wave.objectsToSpawn){
			objCount++;
			this.label.text += objectToSpawn.name;

			if(objCount < wave.objectsToSpawn.Length)
				this.label.text += " and ";
		}
	}
}

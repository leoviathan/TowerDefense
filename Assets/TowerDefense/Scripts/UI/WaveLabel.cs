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
		this.label.text = string.Format("Wave {0}: {1} {2}", waveCount, wave.duration * wave.frequency, wave.objectToSpawn.name);
	}
}

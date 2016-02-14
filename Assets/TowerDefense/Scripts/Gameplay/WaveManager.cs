// ------------------------------------------------------------------------------------------------------------
// 							 WaveManager.cs
// 				 Copyright (c) 2016 Leonardo Lopes
//  	Authors: Leonardo M. Lopes <euleoo@gmail.com> - http://about.me/leonardo_lopes
// ------------------------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System;

public class WaveManager : MonoBehaviour {
	public event Action<Wave> OnWaveStarted;
	public event Action<Wave> OnWaveFinished;
	public event Action AllWavesFinished;

	public Wave[] waves;
	
	private int currentWaveIndex = 0;
	private Spawner spawner;

	private float waveTimer = 0;

	private Wave CurrentWave {
		get {
			return waves[currentWaveIndex];
		}
	}

	public void StartNewWave(){
		StartWave(waves[currentWaveIndex]);
	}

	void Start () {
		this.spawner = FindObjectOfType<Spawner>();
	}

	void StartWave(Wave wave){
		InvokeRepeating("ExecuteWave", 0f, 1f / wave.frequency);

		if(OnWaveStarted != null)
			OnWaveStarted(wave);
	}

	void StopWave(Wave wave){
		CancelInvoke();

		if(OnWaveFinished != null)
			OnWaveFinished(wave);

		waveTimer = 0f;
		currentWaveIndex++;

		if(currentWaveIndex >= waves.Length){
			if(AllWavesFinished != null)
				AllWavesFinished();
		}
	}

	void ExecuteWave(){
		spawner.SpawnObject(CurrentWave.objectToSpawn);

		waveTimer += 1f / CurrentWave.frequency;

		if(waveTimer >= CurrentWave.duration)
			StopWave(CurrentWave);
	}
}

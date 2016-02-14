// ------------------------------------------------------------------------------------------------------------
// 							 GameController.cs
// 				 Copyright (c) 2016 Leonardo Lopes
//  	Authors: Leonardo M. Lopes <euleoo@gmail.com> - http://about.me/leonardo_lopes
// ------------------------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
	public int startingLives = 20;
	public int startingGold = 20;

	private int lives;
	private int gold;
	private int score;

	private WaveManager waveManager;
	private bool allWavesFinished = false;
	[SerializeField]private int aliveEnemies = 0;//Just for editor debuging

	public int Lives {
		get {
			return lives;
		}
	}

	public int Gold {
		get {
			return gold;
		}
	}

	public int Score {
		get {
			return score;
		}
	}
	
	void Start () {
		this.lives = startingLives;
		this.gold = startingGold;

		FindObjectOfType<DestinationBehaviour>().OnEnemyReachedDestination += HandleOnEnemyReachedDestination;
		Spawner spawner = FindObjectOfType<Spawner>();
		spawner.OnGameObjectSpawned += (GameObject obj) => {
			obj.GetComponent<Enemy>().OnEnemyDied += HandleOnEnemyDied;
		};

		waveManager = FindObjectOfType<WaveManager>();
		waveManager.AllWavesFinished += WavesFinished;

		//We check for enemies every second to start a new wave
		InvokeRepeating("CheckForEnemies", 0, 1f);
	}

	void CheckForEnemies(){
		//Debug.Log("Checking for enemies");

		aliveEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;

		if(aliveEnemies == 0){
			if(allWavesFinished)
				Victory();
			else
				waveManager.StartNewWave();
		}
	}

	void HandleOnEnemyDied (Enemy enemy)
	{
		this.score += enemy.score;
		this.gold += enemy.goldCarrying;
	}

	void HandleOnEnemyReachedDestination (GameObject enemy)
	{
		this.lives -= enemy.GetComponent<Enemy>().damage;

		if(this.lives <= 0)
			GameOver();
	}

	void GameOver(){
		Debug.Log("Game over!");
	}

	void WavesFinished ()
	{
		allWavesFinished = true;
		//Debug.Log("Waves finished!");
	}

	void Victory(){
		Debug.Log("Victory!");
	}
}

// ------------------------------------------------------------------------------------------------------------
// 							 GameController.cs
// 				 Copyright (c) 2016 Leonardo Lopes
//  	Authors: Leonardo M. Lopes <euleoo@gmail.com> - http://about.me/leonardo_lopes
// ------------------------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public int startingLives = 20;
	public int startingGold = 20;

	private int lives;
	private int gold;
	private int score;

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
		FindObjectOfType<Spawner>().OnGameObjectSpawned += (GameObject obj) => {
			obj.GetComponent<Enemy>().OnEnemyDied += HandleOnEnemyDied;
		};

		WaveManager waveManager = FindObjectOfType<WaveManager>();
		waveManager.AllWavesFinished += WavesFinished;
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
		Debug.Log("Waves finished!");
	}
}

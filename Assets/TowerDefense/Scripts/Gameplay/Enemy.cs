// ------------------------------------------------------------------------------------------------------------
// 							 Enemy.cs
// 				 Copyright (c) 2016 Leonardo Lopes
//  	Authors: Leonardo M. Lopes <euleoo@gmail.com> - http://about.me/leonardo_lopes
// ------------------------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System;

public class Enemy : MonoBehaviour {
	public event Action<Enemy> OnEnemyDied;

	public float life = 100f;
	public LifeBarBehaviour lifeBar;
	public int damage = 1;
	public int score = 1;
	public int goldCarrying = 1;

	private float initialLife;

	void Start(){
		this.initialLife = life;
	}

	public void TakeDamage(float amount){
		if(amount > 0){
			life -= amount;

			lifeBar.UpdateBar(life / this.initialLife);

			if(life <= 0){
				if(OnEnemyDied != null)
					OnEnemyDied(this);

				Destroy(this.gameObject);
			}
		}
	}
}

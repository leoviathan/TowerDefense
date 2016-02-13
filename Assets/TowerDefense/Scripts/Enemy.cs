﻿// ------------------------------------------------------------------------------------------------------------
// 							 Enemy.cs
// 				 Copyright (c) 2016 Leonardo Lopes
//  	Authors: Leonardo M. Lopes <euleoo@gmail.com> - http://about.me/leonardo_lopes
// ------------------------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public float life = 100f;
	public LifeBarBehaviour lifeBar;

	private float initialLife;

	void Start(){
		this.initialLife = life;
	}

	public void Damage(float amount){
		if(amount > 0){
			life -= amount;

			lifeBar.UpdateBar(life / this.initialLife);

			if(life <= 0)
				Destroy(this.gameObject);
		}
	}
}

// ------------------------------------------------------------------------------------------------------------
// 							 TowerBehaviour.cs
// 				 Copyright (c) 2016 Leonardo Lopes
//  	Authors: Leonardo M. Lopes <euleoo@gmail.com> - http://about.me/leonardo_lopes
// ------------------------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerBehaviour : MonoBehaviour {
	private List<GameObject> enemiesInRange;
	[SerializeField]private GameObject preferedTarget;

	public GameObject PreferedTarget {
		get {
			return preferedTarget;
		}
	}

	// Use this for initialization
	void Start () {
		enemiesInRange = new List<GameObject>();

		InvokeRepeating("SelectBestTarget", 0, .2f);

		foreach(Transform child in this.transform){
			WeaponBehaviour childWeapon = child.GetComponent<WeaponBehaviour>();

			if(childWeapon != null)
				childWeapon.Tower = this;
		}
	}

	void SelectBestTarget(){
		ClearEnemiesList();

		if(preferedTarget != null)
			return;

		float farthestDistance = 0f;

		foreach(GameObject enemy in enemiesInRange){
			if(enemy == null)
				continue;

			if(Vector3.Distance(enemy.transform.position, this.transform.position) >= farthestDistance)
				preferedTarget = enemy;
		}
	}

	void ClearEnemiesList(){
		for(int i = enemiesInRange.Count - 1; i >= 0; i--)
			if(enemiesInRange[i] == null)
				enemiesInRange.RemoveAt(i);
	}

	public void EnemyInRange(GameObject enemy){
		if(!enemiesInRange.Contains(enemy))
			enemiesInRange.Add(enemy);
	}

	public void EnemyOutOfRange(GameObject enemy){
		if(enemiesInRange.Contains(enemy))
			enemiesInRange.Remove(enemy);

		if(enemiesInRange.Count == 0){
			preferedTarget = null;
			return;
		}

		if(preferedTarget == enemy)
			preferedTarget = null;
	}
}

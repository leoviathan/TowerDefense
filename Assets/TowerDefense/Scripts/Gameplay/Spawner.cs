// ------------------------------------------------------------------------------------------------------------
// 							 Spawner.cs
// 				 Copyright (c) 2016 Leonardo Lopes
//  	Authors: Leonardo M. Lopes <euleoo@gmail.com> - http://about.me/leonardo_lopes
// ------------------------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System;

public class Spawner : MonoBehaviour {
	public event Action<GameObject> OnGameObjectSpawned;

	public void SpawnObject(GameObject prefab){
		GameObject spawnedObject = Instantiate<GameObject>(prefab);
		
		spawnedObject.transform.position = this.transform.position;

		//Just for scene organiztion propouses
		spawnedObject.transform.parent = this.transform;
		
		if(OnGameObjectSpawned != null)
			OnGameObjectSpawned(spawnedObject);
	}
}

// ------------------------------------------------------------------------------------------------------------
// 							 Spawner.cs
// 				 Copyright (c) 2016 Leonardo Lopes
//  	Authors: Leonardo M. Lopes <euleoo@gmail.com> - http://about.me/leonardo_lopes
// ------------------------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	public GameObject prefabToSpawn;
	public float frequency;

	// Use this for initialization
	void Start () {
		InvokeRepeating("SpawnObject", 0, 1f/frequency);
	}
	
	void SpawnObject(){
		GameObject spawnedObject = Instantiate<GameObject>(prefabToSpawn);

		spawnedObject.transform.position = this.transform.position;
	}
}

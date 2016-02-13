// ------------------------------------------------------------------------------------------------------------
// 							 DestinationBehaviour.cs
// 				 Copyright (c) 2016 Leonardo Lopes
//  	Authors: Leonardo M. Lopes <euleoo@gmail.com> - http://about.me/leonardo_lopes
// ------------------------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;
using System;

public class DestinationBehaviour : MonoBehaviour {
	public event Action<GameObject> OnEnemyReachedDestination;

	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Enemy"){
			if(OnEnemyReachedDestination != null)
				OnEnemyReachedDestination(other.gameObject);

			Destroy(other.gameObject);
		}
	}
}

// ------------------------------------------------------------------------------------------------------------
// 							 DetectionSphereRange.cs
// 				 Copyright (c) 2016 Leonardo Lopes
//  	Authors: Leonardo M. Lopes <euleoo@gmail.com> - http://about.me/leonardo_lopes
// ------------------------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class DetectionSphereRange : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Enemy")
			SendMessageUpwards("EnemyInRange", other.gameObject);
	}

	void OnTriggerExit(Collider other){
		if(other.gameObject.tag == "Enemy")
			SendMessageUpwards("EnemyOutOfRange", other.gameObject);
	}
}

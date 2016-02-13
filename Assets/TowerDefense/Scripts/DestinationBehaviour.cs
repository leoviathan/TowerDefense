// ------------------------------------------------------------------------------------------------------------
// 							 DestinationBehaviour.cs
// 				 Copyright (c) 2016 Leonardo Lopes
//  	Authors: Leonardo M. Lopes <euleoo@gmail.com> - http://about.me/leonardo_lopes
// ------------------------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class DestinationBehaviour : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		if(other.gameObject.tag == "Enemy")
			Destroy(other.gameObject);
	}
}

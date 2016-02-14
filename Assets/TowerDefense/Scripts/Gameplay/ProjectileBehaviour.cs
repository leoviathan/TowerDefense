// ------------------------------------------------------------------------------------------------------------
// 							 ProjectileBehaviour.cs
// 				 Copyright (c) 2016 Leonardo Lopes
//  	Authors: Leonardo M. Lopes <euleoo@gmail.com> - http://about.me/leonardo_lopes
// ------------------------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class ProjectileBehaviour : MonoBehaviour {
	public float damagePower = 1f;
	public float timeToLive = 1f;

	void Start(){
		Invoke("Destroy", timeToLive);
	}

	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "Enemy"){
			collision.gameObject.SendMessage("TakeDamage", this.damagePower, SendMessageOptions.DontRequireReceiver);
			Destroy(this.gameObject);
		}
	}

	void Destroy(){
		Destroy(this.gameObject);
	}
}

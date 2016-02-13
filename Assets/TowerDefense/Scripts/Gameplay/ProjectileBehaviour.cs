// ------------------------------------------------------------------------------------------------------------
// 							 ProjectileBehaviour.cs
// 				 Copyright (c) 2016 Leonardo Lopes
//  	Authors: Leonardo M. Lopes <euleoo@gmail.com> - http://about.me/leonardo_lopes
// ------------------------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class ProjectileBehaviour : MonoBehaviour {
	public float damagePower = 1f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision) {
		if(collision.gameObject.tag == "Enemy")
			collision.gameObject.SendMessage("TakeDamage", this.damagePower, SendMessageOptions.DontRequireReceiver);

		Destroy(this.gameObject);
	}
}

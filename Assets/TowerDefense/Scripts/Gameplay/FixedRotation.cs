// ------------------------------------------------------------------------------------------------------------
// 							 FixedRotation.cs
// 				 Copyright (c) 2016 Leonardo Lopes
//  	Authors: Leonardo M. Lopes <euleoo@gmail.com> - http://about.me/leonardo_lopes
// ------------------------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class FixedRotation : MonoBehaviour {
	private Quaternion initialRotation;

	// Use this for initialization
	void Start () {
		this.initialRotation = this.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.rotation = this.initialRotation;
	}
}

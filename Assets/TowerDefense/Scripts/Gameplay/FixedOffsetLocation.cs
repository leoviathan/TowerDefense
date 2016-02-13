// ------------------------------------------------------------------------------------------------------------
// 							 FixedOffsetLocation.cs
// 				 Copyright (c) 2016 Leonardo Lopes
//  	Authors: Leonardo M. Lopes <euleoo@gmail.com> - http://about.me/leonardo_lopes
// ------------------------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class FixedOffsetLocation : MonoBehaviour {
	private Vector3 offsetFromParent;

	// Use this for initialization
	void Start () {
		this.offsetFromParent = this.transform.parent.position - this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = this.transform.parent.position - this.offsetFromParent;
	}
}

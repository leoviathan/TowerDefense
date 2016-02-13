// ------------------------------------------------------------------------------------------------------------
// 							 LifeBarBehaviour.cs
// 				 Copyright (c) 2016 Leonardo Lopes
//  	Authors: Leonardo M. Lopes <euleoo@gmail.com> - http://about.me/leonardo_lopes
// ------------------------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class LifeBarBehaviour : MonoBehaviour {
	public GameObject currentLifeBar;

	public void UpdateBar(float lifePercentage){
		if(lifePercentage <= 0)
			lifePercentage = 0f;

		Vector3 barScale = currentLifeBar.transform.localScale;

		barScale.x = lifePercentage;

		currentLifeBar.transform.localScale = barScale;
	}
}

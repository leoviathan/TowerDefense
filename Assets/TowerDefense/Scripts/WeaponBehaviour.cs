// ------------------------------------------------------------------------------------------------------------
// 							 WeaponBehaviour.cs
// 				 Copyright (c) 2016 LeonardoLopes
//  	Authors: Leonardo M. Lopes <euleoo@gmail.com> - http://about.me/leonardo_lopes
// ------------------------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class WeaponBehaviour : MonoBehaviour {
	public float rotationSpeed = 1f;

	private TowerBehaviour tower;
	private bool targetAimed = false;

	public TowerBehaviour Tower {
		get {
			return tower;
		}
		set {
			tower = value;
		}
	}

	public bool TargetAimed {
		get {
			return targetAimed;
		}
	}

	void Start(){
		foreach(Transform child in this.transform){
			CannonBehaviour childCannon = child.GetComponent<CannonBehaviour>();
			
			if(childCannon != null)
				childCannon.Weapon = this;
		}
	}

	void Update () {
		if(this.tower != null && this.tower.PreferedTarget != null)
			AimTarget(this.tower.PreferedTarget.transform);
		else
			targetAimed = false;
	}

	void AimTarget(Transform target){
		//Kill the Y coordinate to avoid rotation in other axis
		Vector3 targetPosition = target.transform.position;
		targetPosition.y = this.transform.position.y;

		Quaternion targetRotation = Quaternion.LookRotation(targetPosition - this.transform.position);

		this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

		this.targetAimed = true;
	}
}

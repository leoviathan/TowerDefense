// ------------------------------------------------------------------------------------------------------------
// 							 CannonBehaviour.cs
// 				 Copyright (c) 2016 Leonardo Lopes
//  	Authors: Leonardo M. Lopes <euleoo@gmail.com> - http://about.me/leonardo_lopes
// ------------------------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class CannonBehaviour : MonoBehaviour {
	public float fireFrequency = .1f;
	public GameObject projectilePrefab;
	public float firePower = 1f;
	public Transform canonEnding;

	private WeaponBehaviour weapon;

	public WeaponBehaviour Weapon {
		get {
			return weapon;
		}
		set {
			weapon = value;
		}
	}

	// Use this for initialization
	void Start () {
		InvokeRepeating("FireCannon", 0, 1f/fireFrequency);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FireCannon(){
		if(!Weapon.TargetAimed)
			return;

		if(projectilePrefab == null){
			Debug.LogError("No projectile for this cannon set");
			return;
		}

		Debug.Log("Fire!");

		GameObject projectile = Instantiate<GameObject>(projectilePrefab);
		projectile.transform.position = this.canonEnding.transform.position;
		projectile.GetComponent<Rigidbody>().AddForce(this.transform.forward * firePower);
	}
}

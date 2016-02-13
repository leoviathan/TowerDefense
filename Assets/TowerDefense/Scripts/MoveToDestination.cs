// ------------------------------------------------------------------------------------------------------------
// 							 MoveToDestination.cs
// 				 Copyright (c) 2016 Leonardo Lopes
//  	Authors: Leonardo M. Lopes <euleoo@gmail.com> - http://about.me/leonardo_lopes
// ------------------------------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

[RequireComponent (typeof(NavMeshAgent))]
public class MoveToDestination : MonoBehaviour {
	private Transform destination;
	private NavMeshAgent agent;
	
	void Start () {
		agent = GetComponent<NavMeshAgent>();

		destination = GameObject.FindWithTag("Finish").transform;

		agent.destination = destination.position;
	}
}

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
public class ControleInimigo : MonoBehaviour
{
	public NavMeshAgent agent;
	public Transform target;
	// Use this for initialization
	void Start ()
	{
		agent = GetComponent<NavMeshAgent> ();
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		agent.SetDestination (target.position);
	}
}


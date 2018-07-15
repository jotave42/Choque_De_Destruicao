using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
public class ControleInimigo : MonoBehaviour
{
	public NavMeshAgent agent;
	public Transform target;
    public bool pause;
	// Use this for initialization
	void Start ()
	{
        pause = false;
		agent = GetComponent<NavMeshAgent> ();
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}
    public void AtualizaPause(bool novoPause)
    {
        pause = novoPause;
        if (pause)
            if(!agent.isStopped)
            agent.isStopped = true;
        else
            agent.isStopped = false;
    }
    // Update is called once per frame
    void Update ()
	{
        if (!pause)
        {
            agent.SetDestination(target.position);
            transform.LookAt(target);
        }
	}
}


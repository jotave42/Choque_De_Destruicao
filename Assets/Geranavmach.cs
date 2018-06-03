using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geranavmach : MonoBehaviour {

	// Use this for initialization
	void Awake ()
    {
        GameObject.FindGameObjectWithTag("chao").GetComponent<Spawnar>().GeraNavMesh();
	}
	
	// Update is called once per frame
	
}

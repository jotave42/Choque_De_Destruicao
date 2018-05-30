using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class criar : MonoBehaviour {
	public GameObject coisa;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.E)) 
		{
			
			GameObject.Instantiate (coisa);
		}
	}
}

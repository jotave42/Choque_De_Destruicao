using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roda : MonoBehaviour {
    public float velocidade=200f,rotx;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        rotx += velocidade * Time.deltaTime;
            gameObject.transform.rotation = Quaternion.Euler(0, rotx, 0);
  
    }
}

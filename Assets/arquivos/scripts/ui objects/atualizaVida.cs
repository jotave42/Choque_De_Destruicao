using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class atualizaVida : MonoBehaviour {
	public GameObject CampoCor;
	void Awake ()
	{
		CampoCor = GameObject.Find ("Fill Area/Fill").gameObject;
	}
	public void Atualiza(float vida)
	{
		if (vida > 80)
			CampoCor.GetComponent<Image> ().color = Color.green;
		else if ((vida > 50) && (vida < 80))
			CampoCor.GetComponent<Image> ().color = Color.yellow;
		else if ((vida > 20) && (vida < 50))
			CampoCor.GetComponent<Image> ().color = new Color32 (255, 142, 0, 255);
		else
			CampoCor.GetComponent<Image> ().color = Color.red;
		if (vida <= 0) 
			CampoCor.GetComponent<Image> ().enabled = false;
		else
			CampoCor.GetComponent<Image> ().enabled = true;
		gameObject.GetComponent<Slider> ().value = vida;
	}
}

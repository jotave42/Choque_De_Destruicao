using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class atualizaPlacar : MonoBehaviour 
{
	public void Atualiza(int pontos)
	{
		gameObject.GetComponent<Text>().text="PONTOS: "+ pontos.ToString();
	}
}

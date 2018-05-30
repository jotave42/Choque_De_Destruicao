using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colidir : MonoBehaviour 
{
	public float vida;
	public int pontos;
	public int dinheiro;
	public float boost;
	// Use this for initialization
	void Start () 
	{
		if (this.gameObject.CompareTag ("caixa")) 
		{
			vida = Random.Range (1.0f, 100f);
			pontos = Random.Range (1, 101);
			dinheiro = Random.Range (1, 11);
			boost = Random.Range (0.1f, 2.0f);

		}
	}
	void deleta()
	{
		Destroy (gameObject);
	}
	public void MandaVida(Collider other,bool inimigo)
	{
		if (inimigo) 
			other.gameObject.GetComponent<controlePlayer> ().MudaVida (vida * -1);
		else
			other.gameObject.GetComponent<controlePlayer> ().MudaVida (vida);
	}
	public void MandaPontos(Collider other)
	{
		other.gameObject.GetComponent<controlePlayer> ().MudaPontos (pontos);
	}
	public void MandaDinheiro(Collider other)
	{
		other.gameObject.GetComponent<controlePlayer> ().MudaDinheiro (dinheiro);
	}
	public void MandaBoost(Collider other)
	{
		other.gameObject.GetComponent<controlePlayer> ().MudaVelMax (boost);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			if ((this.gameObject.CompareTag ("vida")))
				MandaVida (other,false);
			else if(this.gameObject.CompareTag ("inimigo"))
				MandaVida (other,true);
			else if (this.gameObject.CompareTag ("pontos"))
				MandaPontos (other);
			else if (this.gameObject.CompareTag ("dinheiro"))
				MandaDinheiro (other);
			else if (this.gameObject.CompareTag ("boost"))
				MandaBoost (other);
			else if (this.gameObject.CompareTag ("caixa")) 
			{
				int x = Random.Range (0, 5);
				switch (x)
				{
				case 0:
					MandaVida (other,false);
					break;
				case 1:
					MandaVida (other,true);
					break;
				case 2:
					MandaPontos (other);
					break;
				case 3:
					MandaDinheiro (other);
					break;
				case 4:
					MandaBoost (other);
					break;
				}
			}
			deleta ();
		}
	}
		
}

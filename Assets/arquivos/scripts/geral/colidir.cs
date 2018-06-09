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
	void SetaVida(bool inimigo)
	{
		if(inimigo)
			vida = Random.Range (-20.0f, -1.0f);
		else
			vida = Random.Range (20.0f, 100f);
	}
	void SetaPontos()
	{
		pontos = Random.Range (1, 101);
	}
	void SetaDinheito()
	{
		dinheiro = Random.Range (1, 11);
	}
	void SetaBoost()
	{
		boost = Random.Range (0.1f, 1.0f);
	}
	void Start () 
	{
		if (this.gameObject.CompareTag ("caixa")) 
		{
			Random.seed= System.DateTime.Now.Millisecond;
			SetaVida (false);
			SetaPontos();
			SetaDinheito ();
			SetaBoost ();

		}
	}
	void deleta()
	{
		Destroy (gameObject);
	}
	public void MandaVida(Collider other)
	{
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
		if((other.gameObject.CompareTag("Player")) || (other.gameObject.CompareTag("parachoque")))
		{
			Random.seed= System.DateTime.Now.Millisecond;
            bool parachoque = false;
            if (other.gameObject.CompareTag("parachoque"))
            { 
                parachoque = true;
                print(other.gameObject.tag);
                other = other.transform.parent.GetComponent<Collider>();
                print(other.gameObject.tag);
            }

			if ((this.gameObject.CompareTag ("vida")))
			{
				SetaVida (false);
				MandaVida (other);
			} 
			else if (this.gameObject.CompareTag ("inimigo")) 
			{
				SetaVida (true);
                if(parachoque)
                {
                    SetaPontos();
                    MandaPontos(other);
                }
                else
				    MandaVida (other);
			} 
			else if (this.gameObject.CompareTag ("pontos")) 
			{
				SetaPontos ();
				MandaPontos (other);
			} 
			else if (this.gameObject.CompareTag ("dinheiro")) 
			{
				SetaDinheito ();
				MandaDinheiro (other);
			} 
			else if (this.gameObject.CompareTag ("boost")) 
			{
                SetaBoost();

                MandaBoost (other);
			}
			else if (this.gameObject.CompareTag ("caixa")) 
			{
				int x = Random.Range (0, 5);
				switch (x)
				{
				case 0:
					MandaVida (other);
					break;
				case 1:
					MandaVida (other);
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

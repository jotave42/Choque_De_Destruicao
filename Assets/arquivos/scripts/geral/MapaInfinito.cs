using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapaInfinito : MonoBehaviour {

	// Use this for initialization
	public GameObject chao;
	public bool cria =true;
	public float largura = 26f;
	public float NovoX, NovoZ;
	// Use this for initialization
	void Awake ()
	{
		cria = true;
	}
	float tranlada(float PosEixo, float PosLocal,float PosPai,bool negativo)
	{

		float res = PosPai;
		if (negativo)
			res -= largura;
		else
			res += largura;
		return res;
	}
	// Update is called once per frame
	void OnTriggerEnter(Collider other)
	{
		if (cria) 
		{
			if ((other.CompareTag ("parede")) || (other.CompareTag ("canto"))) 
			{
				print (other.name);
				other.gameObject.GetComponent<MapaInfinito> ().cria = false;
				cria = false;
			}
			else 
			{
				if (other.CompareTag ("Player")) 
				{
					if((gameObject.CompareTag ("parede")) || (gameObject.CompareTag ("canto"))) 
					{
						if (gameObject.name.CompareTo ("p2") == 0) 
						{
							NovoX = tranlada (gameObject.transform.position.x, gameObject.transform.localPosition.x, gameObject.transform.parent.position.x, false);
							NovoZ = gameObject.transform.parent.position.z;
						}
						if (gameObject.name.CompareTo ("p4") == 0) 
						{
							NovoX = tranlada (gameObject.transform.position.x, gameObject.transform.localPosition.x, gameObject.transform.parent.position.x, true);
							NovoZ = gameObject.transform.parent.position.z;
						}
						if (gameObject.name.CompareTo ("p1") == 0) 
						{
							NovoZ = tranlada (gameObject.transform.position.z, gameObject.transform.localPosition.z, gameObject.transform.parent.position.z, false);
							NovoX = gameObject.transform.parent.position.x;
						}
						if (gameObject.name.CompareTo ("p3") == 0) 
						{
							NovoZ = tranlada (gameObject.transform.position.z, gameObject.transform.localPosition.z, gameObject.transform.parent.position.z, true);
							NovoX = gameObject.transform.parent.position.x;
						}
						if (gameObject.name.CompareTo ("c1") == 0) 
						{
							NovoX = tranlada (gameObject.transform.position.x, gameObject.transform.localPosition.x, gameObject.transform.parent.position.x,false);
							NovoZ = tranlada (gameObject.transform.position.z, gameObject.transform.localPosition.z, gameObject.transform.parent.position.z,false);
						}
						if (gameObject.name.CompareTo ("c2") == 0) 
						{
							NovoX = tranlada (gameObject.transform.position.x, gameObject.transform.localPosition.x, gameObject.transform.parent.position.x,false);
							NovoZ = tranlada (gameObject.transform.position.z, gameObject.transform.localPosition.z, gameObject.transform.parent.position.z,true);
						}
						if (gameObject.name.CompareTo ("c3") == 0) 
						{
							NovoX = tranlada (gameObject.transform.position.x, gameObject.transform.localPosition.x, gameObject.transform.parent.position.x, true);
							NovoZ = tranlada (gameObject.transform.position.z, gameObject.transform.localPosition.z, gameObject.transform.parent.position.z, true);
						}
						if (gameObject.name.CompareTo ("c4") == 0) 
						{
							NovoX = tranlada (gameObject.transform.position.x, gameObject.transform.localPosition.x, gameObject.transform.parent.position.x, true);
							NovoZ = tranlada (gameObject.transform.position.z, gameObject.transform.localPosition.z, gameObject.transform.parent.position.z, false);
						}

						GameObject NovoChao=Instantiate(chao);
						NovoChao.transform.position= new Vector3(NovoX,0f,NovoZ);
						if (gameObject.name.CompareTo ("p2") == 0)
							NovoChao.transform.Find ("p4").GetComponent<MapaInfinito> ().cria = false;// desabilita o complementar
					    if (gameObject.name.CompareTo ("p4") == 0)
							NovoChao.transform.Find ("p2").GetComponent<MapaInfinito> ().cria = false;// desabilita o complementar
					    if (gameObject.name.CompareTo ("p1") == 0)
							NovoChao.transform.Find ("p3").GetComponent<MapaInfinito> ().cria = false;// desabilita o complementar
					    if (gameObject.name.CompareTo ("p3") == 0)
							NovoChao.transform.Find ("p1").GetComponent<MapaInfinito> ().cria = false;// desabilita o complementar
						if (gameObject.name.CompareTo ("c1") == 0)
							 NovoChao.transform.Find ("c3").GetComponent<MapaInfinito> ().cria = false;// desabilita o complementar
						if (gameObject.name.CompareTo ("c3") == 0)
							NovoChao.transform.Find ("c1").GetComponent<MapaInfinito> ().cria = false;// desabilita o complementar
						if (gameObject.name.CompareTo ("c2") == 0)
							NovoChao.transform.Find ("c4").GetComponent<MapaInfinito> ().cria = false;// desabilita o complementar
						if (gameObject.name.CompareTo ("c4") == 0)
							NovoChao.transform.Find ("c2").GetComponent<MapaInfinito> ().cria = false;// desabilita o complementar
						int NumeroItens = Random.Range(0,15);
						NovoChao.name=NovoChao.name.Replace ("(Clone)", "");
						NovoChao.GetComponent<Spawnar> ().Spawna (NumeroItens);
						

						cria = false;
					}
				}
			}

		}
	}
}

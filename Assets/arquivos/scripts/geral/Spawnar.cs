using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawnar : MonoBehaviour
{
	public GameObject[] Objetos= new GameObject[5];
	// Use this for initialization

	public void Spawna(int cota)
	{

		print (cota);
		List<Vector3> posiscoes = new List<Vector3> ();
		for (int i = 0; i <cota; i++) 
		{
			Random.seed= System.DateTime.Now.Millisecond;
			int sorteado = Random.Range (0, Objetos.Length);
			GameObject NovoObjeto = Instantiate (Objetos [5]) as GameObject;
			print (NovoObjeto.name);
			print (NovoObjeto.transform.lossyScale);
			NovoObjeto.transform.SetParent (gameObject.transform);
			Vector3 posicao;
			do 
			{
				float x =Random.Range(-500f,500f);
				x=x/1000;
				float y =NovoObjeto.transform.localPosition.y;
				float z =Random.Range(-500f,500f);
				z=z/1000;
				posicao=new Vector3(x,y,z);
			} while(posiscoes.Contains(posicao));
			posiscoes.Add (posicao);
			print (NovoObjeto.transform.lossyScale);
			NovoObjeto.transform.localPosition = posicao;
			NovoObjeto.name= NovoObjeto.name.Replace ("(Clone)", "");
			print (NovoObjeto.transform.localPosition);
			print (NovoObjeto.transform.parent.name);
		
		}
	}
}


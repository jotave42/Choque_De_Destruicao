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
		Random.seed =(int)Time.deltaTime;
		List<Vector3> posiscoes = new List<Vector3> ();
		for (int i = 0; i <cota; i++) 
		{
			int sorteado = Random.Range (0, 5);
			GameObject NovoObjeto = Instantiate (Objetos [sorteado]) as GameObject;
			print (NovoObjeto.name);
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
			NovoObjeto.transform.localPosition = posicao;
			NovoObjeto.name= NovoObjeto.name.Replace ("(Clone)", "");
			print (NovoObjeto.transform.localPosition);
			print (NovoObjeto.transform.parent.name);
		
		}
	}
}


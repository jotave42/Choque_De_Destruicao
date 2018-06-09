using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
public class Spawnar : MonoBehaviour
{
	public GameObject[] Objetos= new GameObject[5];
    // Use this for initialization
    public GameObject inimigo;
    public void SpawnaInimigo(int cota)
    {
        for (int i = 0; i < cota / 2; i++)
        {
            List<Vector3> posiscoes = new List<Vector3>();
            GameObject NovoInimigo = Instantiate(inimigo);
            Vector3 posicao;
            float y = NovoInimigo.transform.position.y;
            do
            {
                Random.seed = System.DateTime.Now.Millisecond;
                float x = Random.Range(-13, 14) + transform.position.x;
                float z = Random.Range(-13, 14) + transform.position.z;
                posicao = new Vector3(x, y, z);
            } while (posiscoes.Contains(posicao));
            posiscoes.Add(posicao);
            NovoInimigo.transform.position = posicao;
            NovoInimigo.name = NovoInimigo.name.Replace("(Clone)", "");

        }
    }

    public void Spawna(int cota)
	{
        
		List<Vector3> posiscoes = new List<Vector3> ();
		for (int i = 0; i <cota; i++) 
		{
			Random.seed= System.DateTime.Now.Millisecond;
			int sorteado = Random.Range (0, Objetos.Length);
			GameObject NovoObjeto = Instantiate (Objetos [sorteado]) as GameObject;
			//NovoObjeto.transform.SetParent (gameObject.transform);
			Vector3 posicao;
			do 
			{
				Random.seed= System.DateTime.Now.Millisecond;
				float x =Random.Range(-13.0f,13.0f) + transform.position.x;
				float y =NovoObjeto.transform.position.y;
				float z =Random.Range(-13.0f,13.0f) + transform.position.z;
				posicao=new Vector3(x,y,z);
			} while(posiscoes.Contains(posicao));
			posiscoes.Add (posicao);
			NovoObjeto.transform.position = posicao;
			NovoObjeto.name= NovoObjeto.name.Replace ("(Clone)", "");
		}
    }
    public void GeraNavMesh()
    {
        GetComponent<NavMeshSurface>().BuildNavMesh();
    }
}


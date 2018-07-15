using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
public class Spawnar : MonoBehaviour
{
	public GameObject[] Objetos= new GameObject[5];
    // Use this for initialization
    public GameObject[] inimigos;
    
    public void SpawnaInimigo(int cota)
    {
        for (int i = 0; i < cota / 2; i++)
        {
            Random.InitState(System.DateTime.Now.Millisecond);
            List<float> posX = new List<float>();
            List<float> posZ = new List<float>();
            int ind = Random.Range(0, 3);
            GameObject NovoInimigo = Instantiate(inimigos[ind]);
            Vector3 posicao;
            float x, z;
            float y = NovoInimigo.transform.position.y;
            do
            {
                x = Random.Range(-13.0f, 14.0f) + transform.position.x;
                z = Random.Range(-13.0f, 14.0f) + transform.position.z;
                posicao = new Vector3(x, y, z);
            } while ((posX.Contains(x))&&(posZ.Contains(z)));
            posX.Add(x);
            posZ.Add(z);
            NovoInimigo.transform.position = posicao;
            NovoInimigo.name = NovoInimigo.name.Replace("(Clone)", "");

        }
    }

    public void Spawna(int cota)
	{

        List<float> posX = new List<float>();
        List<float> posZ = new List<float>();
        float x, z, y;
        for (int i = 0; i <cota; i++) 
		{
            Random.InitState(System.DateTime.Now.Millisecond);
            int sorteado = Random.Range (0, Objetos.Length);
			GameObject NovoObjeto = Instantiate (Objetos [sorteado]) as GameObject;
			//NovoObjeto.transform.SetParent (gameObject.transform);
			Vector3 posicao;
            do
            {
                Random.InitState(System.DateTime.Now.Millisecond);
                x = Random.Range(-13, 14) + transform.position.x;
                y = NovoObjeto.transform.position.y;
                z = Random.Range(-13, 14) + transform.position.z;
                posicao = new Vector3(x, y, z);
            } while ((posX.Contains(x)) && (posZ.Contains(z)));
            posX.Add(x);
            posZ.Add(z);
			NovoObjeto.transform.position = posicao;
			NovoObjeto.name= NovoObjeto.name.Replace ("(Clone)", "");
		}
    }
    public void GeraNavMesh()
    {
        GetComponent<NavMeshSurface>().BuildNavMesh();
    }
}


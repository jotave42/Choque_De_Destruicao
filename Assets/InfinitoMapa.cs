using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfinitoMapa : MonoBehaviour {

    // Use this for initialization
    public GameObject chao;
    public float largura = 26f;
    private float NovoX, NovoZ;
    // Use this for initialization


    float tranlada(float PosPai, bool negativo)
    {
        float res = PosPai;
        if (negativo)
            res -= largura;
        else
            res += largura;
        return res;
    }
    // Update is called once per frame
    public void criaChao(Transform viz, int caso)
    {
        //para cria  o chao precisa saber onde  colocalo existem 8 opcao 
        //representamos essa opcoes em uma matriz  3X3  sendo o a pos  1,1 o proprio chao
        //localizada no script vizinhos existe uma  representacao 3x3 
        //vizinhos esta localizado no gameobject chao
        GameObject[] vizinhos = GameObject.FindGameObjectsWithTag("chao");
        GameObject NovoChao;
        switch (caso)
        {
            case 0:
                NovoZ = tranlada(viz.position.z, false);
                NovoX = tranlada(viz.position.x, true);
                break;
            case 1:
                NovoZ = tranlada(viz.position.z, false);
                NovoX = viz.position.x;
                break;
            case 2:
                NovoZ = tranlada(viz.position.z, false);
                NovoX = tranlada(viz.position.x, false);
                break;
            case 3:
                NovoX = tranlada(viz.position.x, true);
                NovoZ = viz.position.z;
                break;
            case 4:
                NovoX = tranlada(viz.position.x, false);
                NovoZ = viz.position.z;
                break;
            case 5:
                NovoZ = tranlada(viz.position.z, true);
                NovoX = tranlada(viz.position.x, true);
                break;
            case 6:
                NovoZ = tranlada(viz.position.z, true);
                NovoX = viz.position.x;
                break;
            case 7:
                NovoZ = tranlada(viz.position.z, true);
                NovoX = tranlada(viz.position.x, false);
                break;

        }
        Vector3 vizPos = new Vector3(NovoX, 0f, NovoZ);
        foreach (GameObject vizinho in vizinhos)
        {
            if (vizinho.transform.position==vizPos)
                return;//sai se deu ruim
        }
        NovoChao = GameObject.Instantiate(chao);
        NovoChao.transform.position = vizPos;
        Random.seed = System.DateTime.Now.Millisecond;
        int NumeroItens = Random.Range(0, 11);
        NovoChao.name = NovoChao.name.Replace("(Clone)", "");
        NovoChao.GetComponent<Spawnar>().Spawna(NumeroItens);
    }
    void OnTriggerEnter(Collider other)
    {
        
            if (other.CompareTag("Player"))
            {

                if (gameObject.CompareTag("parede"))
                {
                    GameObject temp;
                    if ((gameObject.name.CompareTo("p1") == 0) || (gameObject.name.CompareTo("p8") == 0))
                    {
                          criaChao(transform.parent, 1);
                          criaChao(transform.parent, 0);
                          criaChao(transform.parent, 3);

                    }
                    else if ((gameObject.name.CompareTo("p2") == 0)|| (gameObject.name.CompareTo("p3") == 0))
                    {
                        criaChao(transform.parent, 1);
                        criaChao(transform.parent, 2);
                        criaChao(transform.parent, 4);
                    }
                    else if ((gameObject.name.CompareTo("p4") == 0)|| (gameObject.name.CompareTo("p5") == 0))
                    {
                            criaChao(transform.parent, 4);
                            criaChao(transform.parent, 7);
                            criaChao(transform.parent, 6);
                    }
                   
                    else if ((gameObject.name.CompareTo("p6") == 0) || (gameObject.name.CompareTo("p7") == 0))
                    {

                        criaChao(transform.parent, 6);
                        criaChao(transform.parent, 5);
                        criaChao(transform.parent, 3);
                    }
                   
                }
            }

        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MapaInfinito : MonoBehaviour {

    // Use this for initialization
    public GameObject chao;
    public bool cria = true;
    public float largura = 26f;
    public GameObject conectado;
    public vizinhos vizinScript;// public so para debug
    private float NovoX, NovoZ;
    private int NovoCaso;
    // Use this for initialization
    void Awake()
    {
        cria = true;
        // conectado = null;
        vizinScript = transform.parent.GetComponent<vizinhos>();
    }

    float tranlada( float PosPai, bool negativo)
    {

        float res = PosPai;
        if (negativo)
            res -= largura;
        else
            res += largura;
        return res;
    }
    // Update is called once per frame
    public GameObject criaChao(Transform viz, int caso)
    {
        //para cria  o chao precisa saber onde  colocalo existem 8 opcao 
        //representamos essa opcoes em uma matriz  3X3  sendo o a pos  1,1 o proprio chao
        //localizada no script vizinhos existe uma  representacao 3x3 
        //vizinhos esta localizado no gameobject chao
        
        GameObject NovoChao;
        switch (caso)
        {
          
            case 1:
                if (viz.GetComponent<vizinhos>().ChcaVizinho(0, 1) == 1)
                    return null;//sai se ja foi criado
                NovoCaso = 6;
                NovoZ = tranlada(viz.position.z, false);
                NovoX = viz.position.x;
                break;
            case 3:
                if (viz.GetComponent<vizinhos>().ChcaVizinho(1, 0) == 1)
                    return null;//sai se ja foi criado
                NovoCaso = 4;
                NovoX = tranlada(viz.position.x, true);
                NovoZ = viz.position.z;
                break;
            case 4:
                if (viz.GetComponent<vizinhos>().ChcaVizinho(1, 2) == 1)
                    return null;//sai se ja foi criado
                NovoCaso = 3;
                NovoX = tranlada(viz.position.x, false);
                NovoZ = viz.position.z;
                break;
           case 6:
                if (viz.GetComponent<vizinhos>().ChcaVizinho(2, 1) == 1)
                {
                    return null;//sai se ja foi criado
                }
                NovoCaso = 1;
                NovoZ = tranlada(viz.position.z, true);
                NovoX = viz.position.x;
                break;
    
        }
        NovoChao = GameObject.Instantiate(chao);
        setaVizinhanca(NovoChao.transform, caso, viz);
        setaVizinhanca(viz, NovoCaso, NovoChao.transform);
        NovoChao.transform.position = new Vector3(NovoX, 0f, NovoZ);
        Random.seed = System.DateTime.Now.Millisecond;
        int NumeroItens = Random.Range(0, 6);
        NovoChao.name = NovoChao.name.Replace("(Clone)", "");
        //NovoChao.GetComponent<Spawnar>().Spawna(NumeroItens);
        //NovoChao.GetComponent<Spawnar>().GeraNavMesh();
        return NovoChao;
    }
    void  setaVizinhanca(Transform pai, int caso, Transform vizinho)
    {
        switch (caso)
        {
            case 1:
                pai.GetComponent<vizinhos>().InsereVizTrans(2, 1, vizinho);
                pai.GetComponent<vizinhos>().AtualizaVizinhos(2, 1, 1);// diz ao vizinho que este objeto existe
                break;
            case 3:
                pai.GetComponent<vizinhos>().InsereVizTrans(1, 2,vizinho);
                pai.GetComponent<vizinhos>().AtualizaVizinhos(1, 2, 1);// diz ao vizinho que este objeto existe
                break;
            case 4:
                pai.GetComponent<vizinhos>().InsereVizTrans(1, 0, vizinho);
                pai.GetComponent<vizinhos>().AtualizaVizinhos(1, 0, 1);// diz ao vizinho que este objeto existe
                break;
            case 6:
                pai.GetComponent<vizinhos>().InsereVizTrans(0, 1, vizinho);
                pai.GetComponent<vizinhos>().AtualizaVizinhos(0, 1, 1);// diz ao vizinho que este objeto existe
                break;
        }
    }
    int selcionaCaso(string name)
    {//essa funcao e' desenhada  para coperar  com a fungao setaVizinhanca  
        switch (name)
        {
            case "p1":
                return 1;
            case "p2":
                return 1;
            case "p3":
                return 4;
            case "p4":
                return 4;
            case "p5":
                return 6;
            case "p6":
                return 6;
            case "p7":
                return 3;
            case "p8":
                return 3;
        }
        return -1;
    }
	void OnTriggerEnter(Collider other)
	{
		if ((other.CompareTag (gameObject.tag))&&(!conectado)) 
		{
            print("eu: "+gameObject.name+" colidi com "+other.transform.parent.name+" cujo o id de e' "+ other.transform.parent.GetInstanceID().ToString()+"e e' pai do "+other.name);
            conectado = other.transform.parent.gameObject;
            other.transform.GetComponent<MapaInfinito>().conectado = transform.parent.gameObject;
            int caso = selcionaCaso(other.gameObject.name);
            setaVizinhanca(transform.parent, caso,other.transform.parent);
            caso = selcionaCaso(gameObject.name);
            setaVizinhanca(other.transform.parent, caso, transform.parent);
            //     other.gameObject.GetComponent<MapaInfinito> ().cria = false;
            //	cria = false;
        }
		if (cria) 
		{
			if (other.CompareTag ("Player")) 
			{
				
				if(gameObject.CompareTag ("parede")) 
				{
                    GameObject temp;
                    if (gameObject.name.CompareTo("p1") == 0)
                    {
                        temp= criaChao(transform.parent, 1);
                      /* if (!temp)
                            temp = vizinScript.vizTran[0,1].gameObject;
                       if(temp.transform.Find(""))
                        criaChao(temp.transform, 3);
                        criaChao(transform.parent, 3);*/

                    }
                    else if (gameObject.name.CompareTo("p2") == 0)
                    {
                        temp = criaChao(transform.parent, 1);
                      /*  if (!temp)
                            temp = vizinScript.vizTran[0, 1].gameObject;
                        criaChao(temp.transform, 4);
                        criaChao(transform.parent, 4);*/
                    }
                    else if (gameObject.name.CompareTo("p3") == 0)
                    {
                        temp= criaChao(transform.parent, 4);
                     /*  if (!temp)
                            temp = vizinScript.vizTran[1, 2].gameObject;
                        criaChao(temp.transform, 1);
                        criaChao(transform.parent, 1);*/
                    }
                    else if (gameObject.name.CompareTo("p4") == 0)
                    {
                        temp = criaChao(transform.parent, 4);
                    /*    if (!temp)
                            temp = vizinScript.vizTran[1, 2].gameObject;
                        criaChao(temp.transform, 6);
                        criaChao(transform.parent, 6);*/
                    }
                    else if (gameObject.name.CompareTo("p5") == 0)
                    {
                        temp = criaChao(transform.parent, 6);
                      /*  if (!temp)
                            temp = vizinScript.vizTran[2, 1].gameObject;
                        criaChao(temp.transform, 4);
                        criaChao(transform.parent, 4);*/
                    }
                    else if (gameObject.name.CompareTo("p6") == 0)
                    {

                        temp = criaChao(transform.parent, 6);
                    /*    if (!temp)
                            temp = vizinScript.vizTran[2, 1].gameObject;
                        criaChao(temp.transform, 3);
                        criaChao(transform.parent, 3);*/
                    }
                    else if (gameObject.name.CompareTo("p7") == 0)
                    {
                        temp = criaChao(transform.parent, 3);
                      /*  if (!temp)
                            temp = vizinScript.vizTran[1, 0].gameObject;
                        criaChao(temp.transform, 6);
                        criaChao(transform.parent, 6);*/
                    }
                    else
                    {//esse caso e' o p8
                        temp = criaChao(transform.parent, 3);
                       /* if (!temp)
                            temp = vizinScript.vizTran[1, 0].gameObject;
                        criaChao(temp.transform, 1);
                        criaChao(transform.parent, 1);*/
                    }
                }
			}

		}
	}
}

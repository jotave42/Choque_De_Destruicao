using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vizinhos : MonoBehaviour {
    public  int[,] viz = new int [3,3];
    public int[] lin1 = new int[3];
    public int[] lin2 = new int[3];
    public int[] lin3 = new int[3];
    public Transform[,] vizTran = new Transform[3, 3];
    public Transform[] vizTran1 = new Transform[3];
    public Transform[] vizTran2 = new Transform[3];
    public Transform[] vizTran3 = new Transform[3];
    // Use this for initialization
    void Start ()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                vizTran[i, j] = null;
                viz[i,j] = 0;
            }
        }
        viz[1, 1] = 1;
	}
    public void InsereVizTrans(int i, int j, Transform viz)
    {
        vizTran[i, j] = viz;
        if (i == 0)
            vizTran1[j] = viz;
        else if (i == 1)
            vizTran2[j] = viz;
        else
            vizTran3[j] = viz;
    }
    public Transform PegaViz(int i, int j)
    {
        return vizTran[i, j];
    }
    public void AtualizaVizinhos(int i,int j, int valor)
    {
            viz[i,j] = valor;//lin1-lin3 so para debug
        if (i == 0)
            lin1[j] = valor;
        else if (i == 1)
            lin2[j] = valor;
        else
            lin3[j] = valor;
    }
    public int ChcaVizinho(int i,int j)
    {
        return viz[i,j]; 
    }
}

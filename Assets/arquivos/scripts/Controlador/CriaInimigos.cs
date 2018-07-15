using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CriaInimigos : MonoBehaviour
{
    public float TempDificulta = 2f;
    public GameObject player;
    public int limite, qtd;
    // Use this for initialization
    void Start()
    {
        qtd = 0;
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("troca", TempDificulta, TempDificulta);
    }
    void troca()
    {
        if(qtd==15)
        {
            limite++;
            if (limite > 2) limite = 2;
            qtd = 0;
        }
        qtd++;
        player.GetComponent<controlePlayer>().MudaVida(-1.0f);
    }
}
   

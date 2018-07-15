using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class controlePlayer : MonoBehaviour 
{
    public float vida = 100f;
    public int pontos = 0;
    public int dinheiro = 0;
	public GameObject BarraVida;
	public GameObject placar;
    public float turbo=1f;
	public float Velocidade;
    public float VelocidadeRotacao;
	float rotx;
	public bool EmTurb;
    public float dirHorizontal=0f;
    public bool pause;
    public GameObject MenuControle;

    // Use this for initialization
   public void AtualizaPause(bool novoPause)
    {
        pause = novoPause;
    }
    void Start ()
	{
        pause = false;
        EmTurb = false;
		rotx = 0;
		MudaPontos (pontos);
		MudaVida (vida);
        MenuControle = GameObject.FindGameObjectWithTag("MenuScript");

    }
	public void MudaVelMax(float max)
	{
		if (!EmTurb) 
		{
			turbo += max;
			EmTurb = true;
			StartCoroutine (DesativaTurbo ());
		}
	}
    public void ESQUERDA()
    {
        dirHorizontal = -1f;
    }
    public void DIREITA()
    {
        dirHorizontal = 1f;
    }
    public void NaoTuch()
    {
        dirHorizontal = 0f;
    }
    IEnumerator DesativaTurbo()
	{

		yield return new WaitForSeconds(5);
		turbo=1f;
		EmTurb = false;
	}
	public void MudaVida(float NovaVida)
	{	
		vida += NovaVida;
        if (vida <= 0)
        {
            vida = 0;
            MenuControle.GetComponent<MenuScript>().Morto();
        }
        else if (vida > 100)
            vida = 100;
		BarraVida.GetComponent<atualizaVida> ().Atualiza (vida);
	}
	public void MudaPontos(int NovosPontos)
	{
		pontos += NovosPontos;
        placar.GetComponent<TextMeshProUGUI>().text = pontos.ToString() + " pontos";
	}
    public void MudaDinheiro(int NovoDinerio)
	{
		dinheiro+=NovoDinerio;
	}
	// Update is called once per frame
	void Update () 
	{
        if (!pause)
        {
            gameObject.transform.Translate(0, 0,/* Input.GetAxis("Vertical")*/1 * Velocidade * turbo * Time.deltaTime);
            rotx += dirHorizontal * Velocidade * VelocidadeRotacao * Time.deltaTime;
            gameObject.transform.rotation = Quaternion.Euler(0, rotx, 0);
        }

	}
}

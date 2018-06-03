using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

	// Use this for initialization
	void Start ()
	{
		EmTurb = false;
		rotx = 0;
		MudaPontos (pontos);
		MudaVida (vida);
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
			vida = 0;
		else if (vida > 100)
			vida = 100;
		BarraVida.GetComponent<atualizaVida> ().Atualiza (vida);
	}
	public void MudaPontos(int NovosPontos)
	{
		pontos += NovosPontos;
		placar.GetComponent<atualizaPlacar> ().Atualiza (pontos);
	}
	public void MudaDinheiro(int NovoDinerio)
	{
		//pontos = +NovosPontos;
		dinheiro+=NovoDinerio;
	}
	// Update is called once per frame
	void Update () 
	{
		gameObject.transform.Translate (0, 0, Input.GetAxis("Vertical")/*1*/ *Velocidade*turbo*Time.deltaTime);
		//GetComponent<Rigidbody>().AddForce (transform.forward * 20 * Input.GetAxis ("Vertical"), ForceMode.Acceleration); new eeeeee
		rotx+=Input.GetAxis("Horizontal")*Velocidade*VelocidadeRotacao*Time.deltaTime;
		gameObject.transform.rotation= Quaternion.Euler(0,rotx,0);

	}
}

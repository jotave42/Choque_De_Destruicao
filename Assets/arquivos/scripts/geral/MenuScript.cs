using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour {

	public GameObject botaoDePausa;
	public GameObject pauseMenu;
    public GameObject mortoMenu;
    public GameObject[] inimigos;
    public GameObject player;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void envia (bool pausa)
    {
        player = GameObject.FindGameObjectWithTag("Player");
        inimigos = GameObject.FindGameObjectsWithTag("inimigo");
        for (int i = 0; i < inimigos.Length; i++)
        {
            inimigos[i].SendMessage("AtualizaPause", pausa);
        }
        player.SendMessage("AtualizaPause", pausa);
    }
	
	public void LoadScene(string name){
		SceneManager.LoadScene(name);
	}
    public void Morto()
    {
        envia(true);
        mortoMenu.SetActive(true);
        botaoDePausa.SetActive(false);
    }
    public void Pause()
    {
            botaoDePausa.SetActive(false);
            envia(true);
            pauseMenu.SetActive(true);
    }
   public void DesPause()
   {
			botaoDePausa.SetActive(true);
            pauseMenu.SetActive(false);
            envia(false);
   }

	public void SairJogo(){
		Application.Quit();
	}
}

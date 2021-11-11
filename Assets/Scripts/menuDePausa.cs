using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menuDePausa : MonoBehaviour
{   
    public Guardado choto;
    public GameObject jugador;
    public GameObject menuPausa;
    public GameObject menuAyuda;
    public GameObject menu;
    public bool juegoCorriendo = true;

    private void Awake() {
        choto = FindObjectOfType<Guardado>();
        jugador = FindObjectOfType<GameObject>();
    }
    public void reanudar() {
        menuPausa.SetActive(false);
        Time.timeScale = 1.0f;
        cambiarEstado();
    }

    public void comoJugar() {
        menu.SetActive(false);
        menuAyuda.SetActive(true);
    }

    public void entendi() {
        menu.SetActive(true);
        menuAyuda.SetActive(false);
    }

    public void volver(string nivel) {
        Time.timeScale = 1.0f;
        
        choto.guardadoashe();
        cambiarEstado();
        SceneManager.LoadScene(nivel);
    }

    public void salirDelJuego(){
        Application.Quit();
    }

    public void cambiarEstado() {
        juegoCorriendo = !juegoCorriendo;
    }

    public bool isGameRunning() {
        return juegoCorriendo;
    }
}

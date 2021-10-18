using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuFunciones : MonoBehaviour
{
    public GameObject menu;
    public GameObject menuSalida;
    public GameObject config;
    public GameObject menuPausa;
    public GameObject cargaPartida;
    public bool juegoCorriendo = true;
    

    public void cargarEscenaPrueba(string nivel){
        SceneManager.LoadScene(nivel);
    }

    public void Salir() {
        menuSalida.SetActive(true);
    }

    public void confirmarSi() {
        Application.Quit();
    }

    public void confirmarNo() {
        menuSalida.SetActive(false);
    }

    public void Configuraciones() {
        config.SetActive(true);
        menu.SetActive(false);
    }

    public void volverConfiguraciones() {
        config.SetActive(false);
        menu.SetActive(true);
    }

    public void cargarPartida() {
        cargaPartida.SetActive(true);
        menu.SetActive(false);
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.P)) {
            estadoJuego();
        }
    }

    public void estadoJuego() {
        juegoCorriendo = !juegoCorriendo;
        if(juegoCorriendo) {
            menuPausa.SetActive(false);
            Time.timeScale = 1;
        }
        else {
            menuPausa.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public bool isGameRunning() {
        return juegoCorriendo;
    }
}

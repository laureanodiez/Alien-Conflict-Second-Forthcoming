using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuFunciones : MonoBehaviour
{
    public GameObject menuControles;

    public void Awake() {
        menuControles.SetActive(false);
    }
    
    public void cargarEscena(string nivel){
        SceneManager.LoadScene(nivel);
    }

    public void salirDelJuego(){
        Application.Quit();
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class elegirNivel : MonoBehaviour
{
    public GameObject player;
    public GameObject pantalla;
    public GameObject menu;
    // public GameObject nexo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) < 3.0f) {
            pantalla.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E)) {
                menu.SetActive(true);
                // nexo.SetActive(false);
                
            }
        }
        else {
            pantalla.SetActive(false);
        }
    }

    public void cargarNivel(string nivel) {
        SceneManager.LoadScene(nivel);
    }

    public void volverAlNexo() {
        menu.SetActive(false);
    }
}


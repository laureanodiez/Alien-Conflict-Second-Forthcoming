using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class elegirNivel : MonoBehaviour
{
    public GameObject player;
    public GameObject pantalla;
    public GameObject menu;
    public int m=0;
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
                m=1;
                menu.SetActive(true);           
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
        m=0;
    }

    private void OnGUI() {
                if(m==0) {
                    GUI.contentColor = Color.yellow;
                    GUI.Label(new Rect(100, 10, 900, 100), "Acercate a un objeto y"); 
                    GUI.Label(new Rect(100, 40, 900, 100), "presiona E para seleccionarlo");
                }
    }
}


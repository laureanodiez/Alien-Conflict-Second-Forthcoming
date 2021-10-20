using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class zonaVictoria : MonoBehaviour
{
    public GameObject jugador;
    public bool Victoria = false;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            jugador.GetComponent<Jugador>().ganador();
            Victoria = true;
        }
    }
    public void Update() {
        if(Input.GetKeyDown(KeyCode.Return)){
            SceneManager.LoadScene("Nexo");
         }
    }
}

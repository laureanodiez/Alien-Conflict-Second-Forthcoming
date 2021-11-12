using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Display : MonoBehaviour
{
    public Guardado choto;
    public GameObject Jugador1; // Asignar el gameobject del personaje en inspector. Aparentemente la única manera de hacerlo sin que sea demasiado complicado
    public int puntaje;
    public Text contador;
    public TextMeshProUGUI puntosFinal;
    public TextMeshProUGUI puntosFinalVictoria;
    public float tiempo;
    public float limiteTiempo;
    public float salud;
    public bool vivo = true;
    public bool ganar;
    public menuDePausa mp;
    public GameObject menuDerrota;
    public GameObject menuVictoria;
    public float tiempo2 = 0f;
    public AudioSource audioNormal;
    public AudioSource audioPocaVida;
    public AudioSource audioMenuPausa;
    public AudioClip audioVictoria;

    private void Awake() {
        choto = FindObjectOfType<Guardado>();
    }
    public void Update() {

        if(mp.isGameRunning()) {
            if(Jugador1.activeSelf)
                {
                salud = Jugador1.GetComponent<Jugador>().salud;
                puntaje = Jugador1.GetComponent<Jugador>().puntajeJugador;
                tiempo = Jugador1.GetComponent<Jugador>().tiempo;
                limiteTiempo = Jugador1.GetComponent<Jugador>().limiteTiempo;
                ganar = Jugador1.GetComponent<Jugador>().ganar;
                // Están en udapte porque se tienen que actualizar constantemente
                // en el caso del tiempo, es irrelevante que se ejecute cada frame porque 
                // deltaTime va a normalizar el tiempo por otro lado 
            }
            else {
                vivo = false;
                if(Input.GetKeyDown(KeyCode.Return)){
                    SceneManager.LoadScene("Nexo");
                }
            }
            if(salud <= 25) {
                        if(salud > 0) {
                            audioNormal.volume = 0.0f;
                            audioPocaVida.volume = 0.2f;
                            audioMenuPausa.volume = 0.0f;
                        }
                        else {
                            audioNormal.volume = 0.0f;
                            audioPocaVida.volume = 0.0f;
                            audioMenuPausa.volume = 0.0f;
                        }
                    }
                    else {
                        audioNormal.volume = 0.2f;
                        audioPocaVida.volume = 0.0f;
                        audioMenuPausa.volume = 0.0f;
                    }
        }
        else {
            audioNormal.volume = 0.0f;
            audioPocaVida.volume = 0.0f;
            audioMenuPausa.volume = 0.1f;
        }
        if(ganar == false) {
                if (vivo == true){
                    //también el puntaje
                }
                else {
                    if(tiempo2 >= 3f) {
                        menuDerrota.SetActive(true);
                        puntosFinal.text = "Puntaje Final: " + puntaje.ToString();
                        if(Jugador1 != null)
                            Destroy(Jugador1);

                    }
                    else {
                        tiempo2 += Time.deltaTime;
                    }
                }
            }
        else {
            if(tiempo2 >= 3f) {
                menuVictoria.SetActive(true);
                puntosFinalVictoria.text = "Puntaje Final: " + puntaje.ToString();
            }
            else {
                tiempo2 += Time.deltaTime;
            }
            AudioSource.PlayClipAtPoint(audioVictoria, transform.position, 0.3f);
            audioNormal.volume = 0.0f;
            audioPocaVida.volume = 0.0f;
            audioMenuPausa.volume = 0.0f;
        }
    }

    public void reintentar(string nivel) {
        SceneManager.LoadScene(nivel);
        choto.cargarashe();
    }

    public void volverAlNexo() {
        
        SceneManager.LoadScene("Nexo");
    }

    public void volverAlMenu() {
        
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void salir() {
        Application.Quit();
    }
}

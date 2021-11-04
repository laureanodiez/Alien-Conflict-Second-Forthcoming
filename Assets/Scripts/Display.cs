using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Display : MonoBehaviour
{

    public GameObject Jugador1; // Asignar el gameobject del personaje en inspector. Aparentemente la única manera de hacerlo sin que sea demasiado complicado
    public int puntaje;
    public float tiempo;
    public float limiteTiempo;
    public int salud;
    public bool vivo = true;
    public bool ganar;
    public menuDePausa mp;
    public GameObject menuDerrota;
    public GameObject menuVictoria;
    public float tiempo2 = 0f;

    public void Update() {

        if(mp.isGameRunning()) {
            if(Jugador1 != null)
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
        }
        if(ganar == false){
                if (vivo == true){
                    //acá va la barra de salud
                    //también el puntaje
                }
                else {
                    if(tiempo2 >= 3f) {
                        menuDerrota.SetActive(true);
                    }
                    else {
                        tiempo2 += Time.deltaTime;
                    }
                }
            }
            else{
                if(tiempo2 >= 3f) {
                    menuVictoria.SetActive(true);
                }
                else {
                    tiempo2 += Time.deltaTime;
                } 
            }
    }

    private void OnGUI() {
        if(mp.isGameRunning()) {
            if(ganar == false){
                if (vivo == true){
                    GUI.contentColor = Color.green;
                    GUI.Label(new Rect(100, 100, 90, 60), "HP: " + salud);
                    if(tiempo < limiteTiempo)
                    {
                        GUI.contentColor = Color.yellow;
                        GUI.Label(new Rect(100, 10, 90, 60), "Puntaje: " + puntaje);  
                        GUI.Label(new Rect(100, 50, 90, 100), "Tiempo: " + tiempo); 
                    }
                }
            }
        }
    }

    public void reintentar(string nivel) {
        SceneManager.LoadScene(nivel);
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

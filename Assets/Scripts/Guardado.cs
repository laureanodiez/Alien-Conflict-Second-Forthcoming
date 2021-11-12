using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardado : MonoBehaviour
{
    public int puntaje = 0;
    public float saludM = 100f;
    public Habilidad habilidad;
    public GameObject jugador;
    public static Guardado Instance; //la idea de esto es hacer que haya
    // una UNICA instancia de este objeto, y no destruirla nunca cambiando de escena
    // pero destruyendo todos sus duplicados
   
    private void Awake() {
        if(Instance != null){
            Destroy(this);
            return;
        }
        Instance = this;
        GameObject.DontDestroyOnLoad(this);

    }
    private void Update() {
       jugador = GameObject.Find("Player");

        //saludM = jugador.saludMax;
        
    }

    public void guardadoashe() {
        puntaje = jugador.GetComponent<Jugador>().puntajeJugador;
        saludM = jugador.GetComponent<Jugador>().saludMax;
        habilidad = jugador.GetComponent<TieneHablidad>().habilidad;
    }
    
    public void cargarashe() {
        //jugador = FindObjectOfType<Jugador>();
        if(jugador != null){
            jugador.GetComponent<Jugador>().puntajeJugador = puntaje;
            jugador.GetComponent<Jugador>().saludMax = saludM;
            jugador.GetComponent<TieneHablidad>().habilidad = habilidad;
        }
        else{
            jugador = GameObject.Find("Player");
            jugador.GetComponent<Jugador>().puntajeJugador = puntaje;
            jugador.GetComponent<Jugador>().saludMax = saludM;
            jugador.GetComponent<TieneHablidad>().habilidad = habilidad;
        }


    }

}
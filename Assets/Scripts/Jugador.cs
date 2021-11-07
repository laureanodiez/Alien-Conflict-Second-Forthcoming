﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jugador : MonoBehaviour
{
    public int puntajeJugador = 0;
    public Text contador;
    public int cont=0;
    public float tiempo = 0.0f;
    public int limiteTiempo;
    public float salud = 100f;
    public float saludMax = 100f;
    public float volumen;
    public AudioClip clip;
    public AudioClip oof;
    public bool ganar = false;
    private float s;
    
    void Start () {
        contador.text = " " + puntajeJugador;
	}

    public void Update()
    {
        tiempo = tiempo + Time.deltaTime;
        if(salud < 1){
        AudioSource.PlayClipAtPoint(clip, transform.position, volumen);
        Destroy(gameObject);
        salud = 0;
        }
    }

    public void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("BalaEnemigo")){
            recibirDanio(15);
        }
    }

    public void incremento(int valor)
    {
        puntajeJugador = puntajeJugador + valor;
        while(cont <= puntajeJugador) {
            contador.text = " " + cont.ToString();
            cont++;
        }
    }

    public void recibirDanio(int valor){
        AudioSource.PlayClipAtPoint(oof, transform.position, 0.1f);
        salud = salud - valor;
    }

    public void ganador(){
        ganar = true;
        puntajeJugador = puntajeJugador + (100*((int)salud));
    }

    public void curacion(int valor)
    {
        s = salud + valor;
        if(s > 100) {
            salud = 100;
        }
        else {
            salud = salud + valor;
        }
    }
}

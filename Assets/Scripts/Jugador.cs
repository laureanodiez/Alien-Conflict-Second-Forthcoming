﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public int puntajeJugador = 0;
    public float tiempo = 0.0f;
    public int limiteTiempo;
    public float salud = 100f;
    public float saludMax = 100f;
    public float volumen;
    public AudioClip clip;
    public AudioClip oof;
    public bool ganar = false;

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
    }

    public void recibirDanio(int valor){
        AudioSource.PlayClipAtPoint(oof, transform.position, 0.1f);
        salud = salud - valor;
    }

    public void ganador(){
        ganar = true;
    }

    public void curacion(int valor)
    {
        salud = salud + valor;
    }
}

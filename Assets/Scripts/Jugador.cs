using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public int puntajeJugador = 0;
    public float tiempo = 0.0f;
    public int limiteTiempo;
    public int salud = 100;

    public void incremento(int valor)
    {
        puntajeJugador = puntajeJugador + valor;
    }

    public void recibirDanio(int valor){
        salud = salud - valor;
    }


    public void curacion(int valor)
    {
        salud = salud + valor;
    }

    public void Update()
    {
        tiempo = tiempo + Time.deltaTime;
    }
}

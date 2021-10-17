using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    public int valorMoneda = 10; 
    public GameObject jugador;
    public float tiempo;
    public int limite;

    private void Update() {
        tiempo = jugador.GetComponent<Jugador>().tiempo;
        limite = jugador.GetComponent<Jugador>().limiteTiempo;
    }

    private void OnTriggerEnter(Collider other) {
        // Esto es un metodo, al menos para este caso, más efectivo
        // Porque la moneda nunca tiene colision.
        // Estando marcada como trigger, mientras haya tiempo te da puntos
        // y cuando se termina, simplemente la atravesas. Neat.
        if (tiempo < limite){
            if(other.gameObject.CompareTag("Player")){
                jugador.GetComponent<Jugador>().incremento(valorMoneda);
                Destroy(gameObject);
                }
            }
    }
} 

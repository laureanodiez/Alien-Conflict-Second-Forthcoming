using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    private Image barraJugador;
    public float vida;
    public float vidaMax;
    public Text textoVida;
    Jugador jugador;

    private void Start(){
        barraJugador = GetComponent<Image>();
        jugador = FindObjectOfType<Jugador>();
        textoVida.text = ((int)vida).ToString() + "/" + ((int)vidaMax).ToString();
    }

    private void Update() {
        vida = jugador.salud;
        vidaMax = jugador.saludMax;
        barraJugador.fillAmount = vida / vidaMax;
        textoVida.text = ((int)vida).ToString() + "/" + ((int)vidaMax).ToString();
    }
}
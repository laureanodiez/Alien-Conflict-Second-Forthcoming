using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class tiendaDeArmas : MonoBehaviour
{
    public GameObject player;
    public GameObject tienda;
    public GameObject dineroInsuficiente;
    public GameObject menuCompra;
    public GameObject armaYaComprada;
    public GameObject compraRealizada;
    public TextMeshProUGUI puntaje;
    public int puntos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        puntos = player.GetComponent<Jugador>().puntajeJugador;
        if(Vector3.Distance(transform.position, player.transform.position) < 3.0f) {
            if(Input.GetKeyDown(KeyCode.E)) {
                tienda.SetActive(true);
                puntaje.text = "" + puntos.ToString();           
            }
        }
    }

    public void volverAlNexo() {
        tienda.SetActive(false);
    }

    public void insuficiente() {
        menuCompra.SetActive(true);
        dineroInsuficiente.SetActive(false);
    }

    public void comprarArma(int n) {
        // n sería el número de arma
        // según el número se descuenta el precio correspondiente
        // si puntajeJugador < precio entonces no se puede comprar
        // cuando haya una lista de armas compradas, verificar si el jugador ya la tiene y alertar en caso de ser así

        if(n == 2) {
            if(puntos < 5000) {
                menuCompra.SetActive(false);
                dineroInsuficiente.SetActive(true);
            }
            else {
                //acá me tendría que fijar si ya se tiene el arma
                player.GetComponent<Jugador>().puntajeJugador = player.GetComponent<Jugador>().puntajeJugador - 5000;
                compraRealizada.SetActive(true);
            }
        }

        if(n == 3) {
            if(puntos < 8500) {
                menuCompra.SetActive(false);
                dineroInsuficiente.SetActive(true);
            }
        }

        if(n == 4) {
            if(puntos < 12000) {
                menuCompra.SetActive(false);
                dineroInsuficiente.SetActive(true);
            }
        }

        if(n == 5) {
            if(puntos < 20000) {
                menuCompra.SetActive(false);
                dineroInsuficiente.SetActive(true);
            }
        }
    }
}

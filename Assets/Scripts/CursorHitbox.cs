using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHitbox : MonoBehaviour
{
    public GameObject caja;
    public GameObject jugador;
    private bool agarrable = false;
    public int salud;

    private void Update() {

        if(agarrable){
             if(Input.GetMouseButtonDown(0)){
                CursorModos.instance.ActivarCursorAgarrar();
            }
            if(Input.GetMouseButtonUp(0)){
                jugador.GetComponent<Jugador>().curacion(25);
                Destroy(caja);
                OnMouseExit();
            }
        }
    }
    private void OnMouseEnter() {
        CursorModos.instance.ActivarCursorSeleccion();
        agarrable = true;
    }
    private void OnMouseExit() {
        agarrable = false;
        CursorModos.instance.ActivarCursorCrosshair();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display : MonoBehaviour
{

    public GameObject Jugador1; // Asignar el gameobject del personaje en inspector. Aparentemente la única manera de hacerlo sin que sea demasiado complicado
    public int puntaje;
    public float tiempo;
    public float limiteTiempo;
    public int salud;
    public bool vivo = true;
    public MenuFunciones menuFunciones;
    
    private void Start() {
      menuFunciones = FindObjectOfType<MenuFunciones>();
    }

    public void Update() {

        if(menuFunciones.isGameRunning()) {
          if(Jugador1 != null)
        {
        salud = Jugador1.GetComponent<Jugador>().salud;
        puntaje = Jugador1.GetComponent<Jugador>().puntajeJugador;
        tiempo = Jugador1.GetComponent<Jugador>().tiempo;
        limiteTiempo = Jugador1.GetComponent<Jugador>().limiteTiempo;
        // Están en udapte porque se tienen que actualizar constantemente
        // en el caso del tiempo, es irrelevante que se ejecute cada frame porque 
        // deltaTime va a normalizar el tiempo por otro lado 
       }
       else {
         vivo = false;
       }
        }
    }
  
    private void OnGUI() {
      if (vivo == true){
      GUI.contentColor = Color.green;
      GUI.Label(new Rect(100, 100, 90, 60), "HP: " + salud);
      if(tiempo < limiteTiempo)
      {
      GUI.contentColor = Color.black;
      GUI.Label(new Rect(100, 10, 90, 60), "Puntaje: " + puntaje);  
      GUI.Label(new Rect(100, 50, 90, 100), "Tiempo: " + tiempo); 
      }
      else {
        GUI.contentColor = Color.red;
        GUI.Label(new Rect(100, 50, 90, 100), "No hay más tiempo"); 
      }
     }
     else {
        GUI.contentColor = Color.red;
        GUI.Label(new Rect(100, 50, 90, 100), "MORIDO"); 
    }
  }
}

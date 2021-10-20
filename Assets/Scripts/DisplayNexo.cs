using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayNexo : MonoBehaviour
{
    private void OnGUI() {

            GUI.contentColor = Color.yellow;
            GUI.Label(new Rect(100, 10, 900, 100), "Muevasé hacia el teletransportador"); 
            GUI.Label(new Rect(100, 40, 900, 100), "para comenzar la misión"); 
    }
}

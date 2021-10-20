using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorModos : MonoBehaviour
{
    public static CursorModos instance; // averiguar bien qué hace esto
    public Texture2D crosshairs, handOpen, handClosed;
    
    private void Awake() {
        instance = this;
        ActivarCursorCrosshair();
    }
    public void ActivarCursorSeleccion(){
        Cursor.SetCursor(handOpen, Vector2.zero, CursorMode.Auto);
    }
    public void ActivarCursorCrosshair(){
        Cursor.SetCursor(crosshairs, new Vector2(crosshairs.width / 2, crosshairs.height / 2), CursorMode.Auto);
    }
    public void ActivarCursorAgarrar(){
    Cursor.SetCursor(handClosed, Vector2.zero , CursorMode.Auto);
    }
}

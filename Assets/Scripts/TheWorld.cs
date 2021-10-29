using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TheWorld : Habilidad
{

    public override void Activar(GameObject parent)
    {
        Movimiento movement = parent.GetComponent<Movimiento>();
        Time.timeScale = 0.5f;
        movement.speed = 12f;
    }

    public override void Desactivar(GameObject parent)
    {
        Movimiento movement = parent.GetComponent<Movimiento>();
        Time.timeScale = 1f;
        movement.speed = 6f;
    }
}

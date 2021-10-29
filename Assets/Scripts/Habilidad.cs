using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Habilidad : ScriptableObject
{
    public string nombre;
    public float cooldown;
    public float activo;

    public virtual void Activar(GameObject parent) {}

    public virtual void Desactivar(GameObject parent) {}
}

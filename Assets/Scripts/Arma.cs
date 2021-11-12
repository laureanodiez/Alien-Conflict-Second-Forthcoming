using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nueva arma", menuName = "Scriptable Objects/Arma")]
public class Arma : ScriptableObject
{
    [Header ("Nombre arma")]
    public string nombre;
    [Header ("Estadísticas arma")]
    public int daño;
    public int spread;
    public int bulletsPorTap;
    public int reloadTime;
    public int magazineSize;

    [Header ("Modelo arma")]
    public GameObject modeloArma;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ALGOPARAELARM : MonoBehaviour
{
    public int totalDeArmas;
    public int armaActualIndex;

    public GameObject[] armas;
    public GameObject tieneArma;
    public GameObject armaActual;
    public GameObject jugador;
    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.Find("Player");
        totalDeArmas = jugador.GetComponent<Jugador>().Armas.Length;

        //armas = new GameObject[];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueMelee : MonoBehaviour
{
    private GameObject Player;

    void Start() {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void ataque() {
        Player.GetComponent<Jugador>().recibirDanio(15);
    }
}

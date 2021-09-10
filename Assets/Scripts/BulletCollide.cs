using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollide : MonoBehaviour
{
    public GameObject jugador;
    public AudioClip oof;
    public int valor = 15;
    private void OnCollisionEnter(Collision other){

        if(!other.gameObject.CompareTag("Bala")){
            if(other.gameObject.CompareTag("Player")){
                jugador.GetComponent<Jugador>().recibirDanio(valor);
                AudioSource.PlayClipAtPoint(oof, transform.position, 0.1f);
                Destroy(gameObject);
         }
        Destroy(gameObject);
        }
    }
}
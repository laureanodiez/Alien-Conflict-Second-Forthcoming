using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barril : MonoBehaviour
{
    public AudioClip clip;
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Bala")){
        AudioSource.PlayClipAtPoint(clip, transform.position, 1);
        Destroy(gameObject);
        }
    }
}

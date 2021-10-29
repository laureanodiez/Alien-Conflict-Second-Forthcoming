using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollide : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer != 10){
            Destroy(gameObject);
        }
    }
}
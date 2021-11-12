using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollide : MonoBehaviour
{
    private float crono = 3.1f;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.layer != 10){
            Destroy(gameObject);
        }
    }

    private void Update() {
        if(crono > 0){
                    crono -= Time.deltaTime;
                }
                else{
                    Destroy(gameObject);
                }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DispararEnemigo : MonoBehaviour
{
    public Transform listener;
    public Transform attackPoint;
    public GameObject projectile;

    public void ataque() {
        Vector3 direction = listener.position - attackPoint.position; // + new Vector3(0,listener.position.y,0)
        GameObject currentBullet = Instantiate(projectile, attackPoint.position, Quaternion.identity);
        currentBullet.transform.forward = direction.normalized;

        Rigidbody rb = currentBullet.GetComponent<Rigidbody>();
        rb.AddForce(direction.normalized * 15f, ForceMode.Impulse);
    }
}

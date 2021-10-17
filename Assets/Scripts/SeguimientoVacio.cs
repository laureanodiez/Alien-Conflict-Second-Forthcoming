using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class SeguimientoVacio : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    void Update()
    {
        if(player != null)
        transform.position = player.position + offset;
}
}

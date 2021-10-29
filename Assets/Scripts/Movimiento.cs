using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    [SerializeField] public float speed = 6.0f;
    private Vector3 movimiento = new Vector3(0,0,0);
    private Vector3 movimientoZ;
    private Vector3 movimientoX;

    #region Datamembers
 
    #region Editor Settings

    [SerializeField] private LayerMask groundMask;

    #endregion
    #region Private Fields

    private Camera mainCamera;

    #endregion

    #endregion


    #region Methods

    #region Unity Callbacks

    private void Start()
    {
        // Cache the camera, Camera.main is an expensive operation.
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // var horizontal = Input.GetAxis("Horizontal");
        // var vertical = Input.GetAxis("Vertical");
        // transform.Translate(new Vector3(horizontal, 0, vertical) * (speed * Time.deltaTime));
        movimiento = new Vector3(0,0,0);
        movimientoZ = new Vector3(0,0,0);
        movimientoX = new Vector3(0,0,0);
        
        if(Input.GetKey(KeyCode.S)){
            movimientoZ = new Vector3(0,0,1);
        }
        if(Input.GetKey(KeyCode.D)){
            movimientoX = new Vector3(-1,0,0);
        }
        if(Input.GetKey(KeyCode.W)){
            movimientoZ = new Vector3(0,0,-1);
        }
        if(Input.GetKey(KeyCode.A)){
            movimientoX = new Vector3(1,0,0);

        }
        movimiento = movimientoZ + movimientoX;
        movimiento.Normalize();
        transform.position += movimiento * speed * Time.deltaTime;

        Aim();
    }

    #endregion

    private void Aim()
    {
        var (success, position) = GetMousePosition();
        if (success)
        {
            // Calculate the direction
            var direction = position - transform.position;

            // You might want to delete this line.
            // Ignore the height difference.
            direction.y = 0;

            // Make the transform look in the direction.
            transform.forward = direction;
        }
    }

    private (bool success, Vector3 position) GetMousePosition()
    {
        var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
        {
            // The Raycast hit something, return with the position.
            return (success: true, position: hitInfo.point);
        }
        else
        {
            // The Raycast did not hit anything.
            return (success: false, position: Vector3.zero);
        }
    }

    #endregion
}

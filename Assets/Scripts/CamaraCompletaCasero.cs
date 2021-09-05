using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class CamaraCompletaCasero : MonoBehaviour
// Seguimiento de camara totalmente funcional que debería fusionar un seguimiento
// sencillo (hecho a mano) con un mouse relativamente libre (robado de standard assets y modificado)
{
        public Vector2 rotationRange = new Vector3(70, 70);
        public float rotationSpeed = 4;
        public float dampingTime = 0.3f;
        public bool autoZeroVerticalOnMobile = true;
        public bool autoZeroHorizontalOnMobile = false;
        public bool relative = true;
        
        
        private Vector3 m_TargetAngles;
        private Vector3 m_FollowAngles;
        private Vector3 m_FollowVelocity;
        private Quaternion m_OriginalRotation;

    public Vector3 offset;
    // Esto declara un vector de 3 componentes, que seteamos como el offset desde el inspector
    // Tip: X = 0 Z = -3, porque queremos que esté detras de la bola, y Y = 2 o 3, para que este elevada
   
    public Transform player;
    // Tomamos las coordenadas (transform) del objeto a seguir. Esto tambien
    // es necesario asignarlo desde el inspector

    private void Start()
        {
            m_OriginalRotation = transform.localRotation;
        }

    void LateUpdate()
    {
        if (!player)
			return; // Si no hay nada que seguir, no hay nada que seguir.

        transform.position = player.position + offset;
        // Transformamos la posición de nuestra camara y la convertimos en 
        // "Posicion de la pelota + el offset (corrido) que seteamos
        // Acá termina el seguimiento del objeto, el resto es la parte de mouse que me robé
        

         // we make initial calculations from the original local rotation
            transform.localRotation = m_OriginalRotation;

            // read input from mouse or mobile controls
            float inputH;
            float inputV;
            if (relative)
            {
                inputH = CrossPlatformInputManager.GetAxis("Mouse X");
                inputV = CrossPlatformInputManager.GetAxis("Mouse Y");

                // wrap values to avoid springing quickly the wrong way from positive to negative
                if (m_TargetAngles.y > 180)
                {
                    m_TargetAngles.y -= 360;
                    m_FollowAngles.y -= 360;
                }
                if (m_TargetAngles.x > 180)
                {
                    m_TargetAngles.x -= 360;
                    m_FollowAngles.x -= 360;
                }
                if (m_TargetAngles.y < -180)
                {
                    m_TargetAngles.y += 360;
                    m_FollowAngles.y += 360;
                }
                if (m_TargetAngles.x < -180)
                {
                    m_TargetAngles.x += 360;
                    m_FollowAngles.x += 360;
                }

#if MOBILE_INPUT
            // on mobile, sometimes we want input mapped directly to tilt value,
            // so it springs back automatically when the look input is released.
			if (autoZeroHorizontalOnMobile) {
				m_TargetAngles.y = Mathf.Lerp (-rotationRange.y * 0.5f, rotationRange.y * 0.5f, inputH * .5f + .5f);
			} else {
				m_TargetAngles.y += inputH * rotationSpeed;
			}
			if (autoZeroVerticalOnMobile) {
				m_TargetAngles.x = Mathf.Lerp (-rotationRange.x * 0.5f, rotationRange.x * 0.5f, inputV * .5f + .5f);
			} else {
				m_TargetAngles.x += inputV * rotationSpeed;
			}
#else
                // with mouse input, we have direct control with no springback required.
                m_TargetAngles.y += inputH*rotationSpeed;
                m_TargetAngles.x += inputV*rotationSpeed;
#endif

                // clamp values to allowed range
                m_TargetAngles.y = Mathf.Clamp(m_TargetAngles.y, -rotationRange.y*0.5f, rotationRange.y*0.5f);
                m_TargetAngles.x = Mathf.Clamp(m_TargetAngles.x, -rotationRange.x*0.5f, rotationRange.x*0.5f);
            }
            else
            {
                inputH = Input.mousePosition.x;
                inputV = Input.mousePosition.y;

                // set values to allowed range
                m_TargetAngles.y = Mathf.Lerp(-rotationRange.y*0.5f, rotationRange.y*0.5f, inputH/Screen.width);
                m_TargetAngles.x = Mathf.Lerp(-rotationRange.x*0.5f, rotationRange.x*0.5f, inputV/Screen.height);
            }

            // smoothly interpolate current values to target angles
            m_FollowAngles = Vector3.SmoothDamp(m_FollowAngles, m_TargetAngles, ref m_FollowVelocity, dampingTime);

            // update the actual gameobject's rotation
            transform.localRotation = m_OriginalRotation*Quaternion.Euler(-m_FollowAngles.x, m_FollowAngles.y, 0);
            
            //transform.LookAt(player);
    }
}
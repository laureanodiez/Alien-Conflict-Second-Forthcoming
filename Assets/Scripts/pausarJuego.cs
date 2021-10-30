using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausarJuego : MonoBehaviour
{
    public GameObject menuPausa;
    public menuDePausa mp;

    // Start is called before the first frame update
    void Start()
    {
        // mp = menuDePausa();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)) {
            if(mp.isGameRunning()) {
                menuPausa.SetActive(true);
                Time.timeScale = 0.0f;
                mp.cambiarEstado();
            }
        }
    }
}

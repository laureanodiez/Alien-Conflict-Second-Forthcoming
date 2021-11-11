using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nivelDos : MonoBehaviour
{
    public GameObject zonaVictoria;
    public GameObject boss;
    public GameObject puerta;
    public GameObject llave;
    public float saludBoss;

    // Start is called before the first frame update
    void Start()
    {
        saludBoss = boss.GetComponent<EnemyAITutorial>().salud;
    }

    // Update is called once per frame
    void Update()
    {
        saludBoss = boss.GetComponent<EnemyAITutorial>().salud;
        if(saludBoss <= 0) {
            zonaVictoria.SetActive(true);
        }
    }
}

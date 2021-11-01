using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastillasBase: MonoBehaviour{
    public GameObject dejar_antes_de_morir;

    public float cantidad_personalizada = 5;

    public GameObject[] tipo_pastillas;

    void Start(){
        int largo_elementos = tipo_pastillas.Length;
        
        for(int indice = 0; indice < largo_elementos; indice++) {
            tipo_pastillas[indice].SetActive(false);
        }

        tipo_pastillas[Random.Range(0, largo_elementos)].SetActive(true);

    }

    void Update(){}


    private void OnTriggerEnter(Collider otro) {
        if(otro.gameObject.CompareTag("Jugador")) {
            otro.gameObject.GetComponent<JugadorEstado>().agregar_salud_mental(cantidad_personalizada);

            if(dejar_antes_de_morir != null)
                Instantiate(dejar_antes_de_morir);

            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastillasBase: MonoBehaviour{
    public GameObject dejar_antes_de_morir;

    public float cantidad_personalizada = 5;

    void Start(){
        
    }

    void Update(){
        
    }


    private void OnTriggerEnter(Collider otro) {
        if(otro.gameObject.CompareTag("Jugador")) {
            otro.gameObject.GetComponent<JugadorEstado>().agregar_salud_mental(cantidad_personalizada);

            if(dejar_antes_de_morir != null)
                Instantiate(dejar_antes_de_morir);

            Destroy(gameObject);
        }
    }
}

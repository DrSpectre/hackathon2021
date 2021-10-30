using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataforma: MonoBehaviour{
    public GameObject camarada;

    public bool es_una_ilusion = false;

    void Start(){
        if(es_una_ilusion)
            convertir_a_iusion();

        if(camarada != null) {
            camarada.SetActive(false);
        }
    }

    void Update(){
        
    }

    public void convertir_a_iusion() {
        if(es_una_ilusion) {
            GetComponent<BoxCollider>().isTrigger = true;
        }
    }

    private void OnTriggerEnter(Collider otro) {
        if(otro.gameObject.CompareTag("Jugador")) {
            GetComponent<Animation>().Play();
        }
    }

    public void mostrar_camarada() {
        if(es_una_ilusion || camarada == null)
            return;

        camarada.SetActive(true);

        Animation anima = camarada.GetComponent<Animation>();
        
        if(anima != null)
            anima.Play();

        else
            Debug.LogError("El objeto debe tener un animation con un clip para poder mostrar y activar. Por favor añadir uno.");
    }
}

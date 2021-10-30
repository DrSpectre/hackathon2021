using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataforma: MonoBehaviour{
    public bool es_una_ilusion = false;

    void Start(){
        if(es_una_ilusion)
            convertir_a_iusion();
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
}

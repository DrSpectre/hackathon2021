using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvitaEscape: MonoBehaviour{
    public GameObject punto_reaparicion;

    void Start(){
        
    }

    void Update(){
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Jugador")) {
            other.gameObject.transform.position = punto_reaparicion.transform.position;
        }
    }
}

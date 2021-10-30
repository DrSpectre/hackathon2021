using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastillasBase: MonoBehaviour{
    void Start(){
        
    }

    void Update(){
        
    }


    private void OnTriggerEnter(Collider otro) {
        if(otro.gameObject.CompareTag("Jugador")) {
        }
    }
}

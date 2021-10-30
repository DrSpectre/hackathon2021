using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecolectorPlataformas: MonoBehaviour{
    public JugadorEstado reportar_a;
    
    public string nombre_plataforma = "Plataforma"; 

    void Start(){ }

    void Update(){ }

    private void OnTriggerEnter(Collider otro) {
        if(otro.gameObject.CompareTag(nombre_plataforma)) {
            reportar_a.agregar_plataforma(otro.gameObject);
        }
    }

    private void OnTriggerExit(Collider otro) {
        if(otro.gameObject.CompareTag(nombre_plataforma)){
            reportar_a.agregar_plataforma(otro.gameObject);
        }
    }
}

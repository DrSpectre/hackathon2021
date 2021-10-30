using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMobil: MonoBehaviour {
    public GameObject limite_izq;
    public GameObject limite_der;

    private bool movimiento_a_izq;

    public float veocidad = 5F;

    void Start(){}

    void Update(){
        mover_y_verificar();
    }

    void mover_y_verificar(){ 
        Vector3 mov = transform.position;

        if(transform.position.x > limite_der.transform.position.x){ 
            movimiento_a_izq = true;
        }

        if(transform.position.x < limite_izq.transform.position.x){
            movimiento_a_izq = false;
        }

        transform.position += Vector3.right * veocidad * ((movimiento_a_izq)  ? -1: 1);
    }
}

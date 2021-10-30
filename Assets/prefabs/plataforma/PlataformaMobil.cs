using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMobil: MonoBehaviour {
    public float tiempo_viaje;
    
    public Transform limite_izq;
    public Transform limite_der;

    private Vector3 posicion_actual;
    private Rigidbody cuerpo_muerto;
    
    private CharacterController jugador_atrapado;


    void Start(){
        cuerpo_muerto = GetComponent<Rigidbody>();    
    }


    private void FixedUpdate() {
        posicion_actual = Vector3.Lerp(limite_izq.position, limite_der.position, Mathf.Cos(Time.time / tiempo_viaje * Mathf.PI * 2) * -.5F +.5F);
        cuerpo_muerto.MovePosition(posicion_actual);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Jugador")) {
            jugador_atrapado = other.gameObject.GetComponent<CharacterController>();
        }
    }

    private void OnTriggerStay(Collider other) {
        if(other.gameObject.CompareTag("Jugador")) {
            jugador_atrapado.Move(cuerpo_muerto.velocity * Time.deltaTime);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Jugador")) {
            jugador_atrapado = null;
        }
    }
}



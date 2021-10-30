using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EstadosPersonaje {
    saltando,
    caminando,
    quieto,
    en_aire
}

public class Jugador: MonoBehaviour{

    public float gravedad = 9.8F;
    public float velocidad = 0.8F;
    public float salto_fuerza = 10F;

    private float direccion;
    private float caida_fuerza;

    private CharacterController controlador;

    void Start(){
        controlador = gameObject.GetComponent<CharacterController>();

        caida_fuerza = -gravedad;
    }
    
    private void Update() {
         if(Input.GetKeyDown(KeyCode.Space) && controlador.isGrounded) {
            saltar();
         }
    }

    void FixedUpdate(){
        direccion = Input.GetAxis("Horizontal");

        moverse();
    }

    void moverse(){
        controlador.Move(new Vector3(Input.GetAxis("Horizontal") * velocidad, calcular_fuerza_gravedad(), 0));
    }

    void saltar(){
        caida_fuerza = salto_fuerza;
        moverse();
    }

    float calcular_fuerza_gravedad(){
        if((controlador.isGrounded || caida_fuerza < -gravedad) && caida_fuerza < salto_fuerza - 15F) {
            if(controlador.isGrounded) 
                caida_fuerza = 0;

            else if(caida_fuerza < -gravedad*4)
                caida_fuerza = -gravedad*4;

            return caida_fuerza;
        }

        if(controlador.velocity.y > -gravedad){
            caida_fuerza -= (gravedad * Time.deltaTime);
        }

        return caida_fuerza;
    }
}
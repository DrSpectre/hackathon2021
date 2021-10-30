using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador: MonoBehaviour{
    public float gravedad = 9.8F;
    public float velocidad = 0.8F;
    public float salto_fuerza = 10F;

    private float direccion;
    private float caida_fuerza;

    private bool pre_fase;

    private CharacterController controlador;

    void Start(){
        controlador = gameObject.GetComponent<CharacterController>();

        caida_fuerza = -gravedad;
    }
    
    void Update() {
         if(Input.GetKey(KeyCode.Space) && controlador.isGrounded) {
            saltar();
         }
    }

    void FixedUpdate(){
        direccion = Input.GetAxis("Horizontal");

        moverse();
    }

    void moverse(){
        controlador.Move(new Vector3(direccion * velocidad, calcular_fuerza_gravedad(), 0));
        Debug.Log("--> " + caida_fuerza);
        Debug.Log("--> " + pre_fase);

    }

    void saltar(){
        Debug.Log("--> <--");
        pre_fase = true;
        caida_fuerza = 2F;
        moverse();
    }

    float calcular_fuerza_gravedad(){
        if((controlador.isGrounded || caida_fuerza < -gravedad * 4) && !pre_fase) {
            if(controlador.isGrounded){ 
                caida_fuerza = 0;
                pre_fase = false;
            }

            else if(caida_fuerza < -gravedad * 4)
                caida_fuerza = -gravedad * 4;

            return caida_fuerza;
        }

        if(pre_fase) {
            caida_fuerza += (salto_fuerza * Time.deltaTime);
        }

        if(caida_fuerza > salto_fuerza && pre_fase) {
            pre_fase = false;
        }

        
        if(!pre_fase && controlador.velocity.y > -gravedad){
            caida_fuerza -= (gravedad * Time.deltaTime);
        }

        return caida_fuerza;
    }
}
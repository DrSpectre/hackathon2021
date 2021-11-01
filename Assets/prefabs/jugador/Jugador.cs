using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador: MonoBehaviour{
    public bool en_debuugeo;

    public float gravedad = 9.8F;
    public float velocidad = 0.8F;
    public float salto_fuerza = 10F;

    public Animator anima;
    public GameObject titere;
    
    private CharacterController controlador;

    private float direccion;
    private float caida_fuerza;

    private bool pre_fase;

    //COntroador de joystick
    //private float movimineto_horizontal = 0F;
    public Joystick palanquita;

    void Start(){
        controlador = gameObject.GetComponent<CharacterController>();

        caida_fuerza = -gravedad;

        // anima = GetComponent<Animator>();
    }
    
    void Update() {
         if(Input.GetKey(KeyCode.Space) && controlador.isGrounded) {
            saltar();
         }
    }

    void FixedUpdate(){
        if(en_debuugeo)
            direccion = Input.GetAxis("Horizontal");

        else
            direccion = palanquita.Horizontal;

        moverse();
    }

    void moverse(){
        //Controa los estados de animacion ligeramente
        anima.SetBool("caminando", direccion != 0);
        anima.SetBool("saltando", controlador.isGrounded);
        anima.SetBool("quieto", direccion == 0);

        if(direccion != 0){
            // Falta impementar la rotacion del personaje
            //titere.transform.LookAt(transform.position + Vector3.down * direccion);
            if(direccion > 0)
                //titere.transform.Rotate(0, 90, 0);
                titere.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
            if(direccion < 0)
                //titere.transform.Rotate(0, -90, 0);
                titere.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
        }

        controlador.Move(new Vector3(direccion * velocidad, calcular_fuerza_gravedad(), 0));
        crear_raycast();
    }

    public void saltar(){
        // Salida de emergencia para usarse de manera externa
        if(!controlador.isGrounded)
            return;

        anima.SetBool("saltando", true);

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

    void crear_raycast(){ 
        // -> Validacion de raycast
        RaycastHit rayito_de_luz;

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), 
                out rayito_de_luz, 1.65F)){
            transform.parent = rayito_de_luz.collider.gameObject.transform;
        }
        else{
            transform.parent = null;
        }

    }

    private void OnCollisionEnter(Collision choquue) {
        Debug.Log("Accede a coisoin");
        if(choquue.gameObject.GetComponent<PlataformaMobil>() != null) {
            transform.parent = choquue.gameObject.transform;
        }
    }

    private void OnCollisionExit(Collision choque) {
        if(choque.gameObject.GetComponent<PlataformaMobil>() != null) {
            transform.parent = null;
        }
    }
}
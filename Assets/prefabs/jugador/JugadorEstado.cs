using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorEstado: MonoBehaviour{
    public float cantidad_necesaria_ayuda = 5F;

    // private float indicador_esquizofrenia = 20F;

    private float salud_mental = 50F;

    public List<GameObject> plataformas_cercanas;

    void Start(){}

    void Update(){
        if(Input.GetButtonDown("Fire3") && salud_mental >= cantidad_necesaria_ayuda) {
            Debug.Log("Shift o Ctr");

            salud_mental -= cantidad_necesaria_ayuda;
            plataformas_cercanas.ForEach(
                delegate (GameObject plata) { 
                    plata.GetComponent<plataforma>().mostrar_camarada();
                }
            );
        }
    }

    public void agregar_salud_mental(){ 
        agregar_salud_mental(5F);
    }

    public void agregar_salud_mental(float cantidad) {
        salud_mental += cantidad;
    }


    public void agregar_plataforma(GameObject plataforma){
        plataformas_cercanas.Add(plataforma);
    }

    public void quitar_plataforma(GameObject plataforma){ 
        plataformas_cercanas.Remove(plataforma);
    }
}

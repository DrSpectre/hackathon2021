using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraJugador: MonoBehaviour{
    public Transform enfoque_de_camara;


    void Start(){}

    void Update(){
        if(enfoque_de_camara != null) {
            transform.position = new Vector3(transform.position.x, enfoque_de_camara.position.y, transform.position.z);
        }
    }
}

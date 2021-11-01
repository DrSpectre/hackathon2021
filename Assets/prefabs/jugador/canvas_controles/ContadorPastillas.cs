using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorPastillas: MonoBehaviour{
    public Image[] iconos;
    public bool debug;

    private int indice;

    void Start(){
        indice = iconos.Length - 1;
    }

    void Update(){
        if(debug && Input.GetKeyDown(KeyCode.R)){
            retirar_medicamento();    
        }
    }
    
    public void retirar_medicamento(){
        if(indice < 0)
            return;

        iconos[indice].gameObject.SetActive(false);
        indice -= 1;
    }

}

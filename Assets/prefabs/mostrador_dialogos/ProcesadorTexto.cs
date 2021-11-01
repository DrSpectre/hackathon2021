using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface contiene_animacion{
    public void iniciar_animacion();
    public void detener_animacion();
}

[System.Serializable]
public class Dialogo{
    public int ID;
    public string dialogo;
    public int siguiente_id;
}

[System.Serializable]
public class Dialogos{ 
    public Dialogo[] dialogos;
}

public class ProcesadorTexto: MonoBehaviour{
    public bool esta_activo = false;
    public bool bloquear = true;

    public TextAsset dialogos_json;
    public GameObject cuadro_texto;
    public Text donde_mostrar_texto;

    private int dialogo_actual = -2;

    private Dialogos texto;
    void Start(){
        Debug.Log("dialog:" + dialogos_json);


        if(dialogos_json != null)
            texto = JsonUtility.FromJson<Dialogos>(dialogos_json.text);

        if(texto != null)
            dialogo_actual = -1;

        Debug.Log("textto actual" + dialogo_actual);
        Debug.Log("textto" + texto.dialogos.Length);

        cuadro_texto.SetActive(false);
        donde_mostrar_texto.gameObject.SetActive(false);
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.F)) {
            siguiente_dialogo();
        }
    }

    public void mostrar_dialogos(bool activar){
        esta_activo = activar;

        
        cuadro_texto.SetActive(activar);
        donde_mostrar_texto.gameObject.SetActive(activar);
    }

    public void mostrar_dialogos() {
        mostrar_dialogos(true);
    }

    public void siguiente_dialogo(){
        if(!esta_activo) {
            mostrar_dialogos();
        }

        dialogo_actual += 1;

        int dialogos_largo = texto.dialogos.Length;

        Dialogo dialogo_actual_objeto = null;

        if(dialogo_actual > dialogos_largo - 1){
            mostrar_dialogos(false);
            return;
        }
        
        else{
            dialogo_actual_objeto = texto.dialogos[dialogo_actual];
        }

        if(dialogo_actual_objeto != null && dialogo_actual_objeto.siguiente_id != 0) {
            dialogo_actual = dialogo_actual_objeto.siguiente_id;
        }
        else
            dialogo_actual += 1;

        donde_mostrar_texto.text = dialogo_actual_objeto.dialogo;
    }

}
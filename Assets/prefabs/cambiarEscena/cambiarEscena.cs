using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambiarEscena : MonoBehaviour
{
    public void LoadScene(string escena)
    {
        SceneManager.LoadScene(escena);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}

using UnityEngine;
using UnityEngine.SceneManagement; // cambios de escena

public class MenuInicio : MonoBehaviour
{   

    public GameObject CanvaMenu; // referencia al menu de inicio


    void Start()
    {
        // mostrar el canva menu al iniciar el nivel
        if (CanvaMenu != null)
        {
            CanvaMenu.SetActive(true);
        }
    }

    // salir del juego
    public void Salir()
    {
        Application.Quit();
    }

    // iniciar juego
    public void Jugar()
    {
        SceneManager.LoadScene("LvL1"); // nombre de la escena
    }
}

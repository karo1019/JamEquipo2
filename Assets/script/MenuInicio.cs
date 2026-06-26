using UnityEngine;
using UnityEngine.SceneManagement; // cambios de escena

public class MenuInicio : MonoBehaviour
{   

    public GameObject CanvaMenu; // referencia al menu de inicio
    public GameObject botonplay; // referencia al boton de inicio
    public GameObject botonquit; // referencia al boton de salir

    public int SceneBuildIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // mostrar el canva menu al iniciar el nivel
        if (CanvaMenu != null)
        {
            CanvaMenu.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // salir del juego
    void QuitGame()
    {
        Application.Quit();
    }

    // iniciar juego
    void play()
    {
        SceneManager.LoadScene(SceneBuildIndex, LoadSceneMode.Single);
    }
}

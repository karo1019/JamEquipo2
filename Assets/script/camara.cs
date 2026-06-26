using UnityEngine;
using UnityEngine.InputSystem; // nuevo sistema :p

public class camara : MonoBehaviour
{

    public float sensitivity = 100f; // sensibilidad del raton
    public Transform playerbody; // referencia al cuerpo del jugadro

    // movimineto del raton
    private float mouseX;
    private float mouseY;

    private float xRotation = 0f; // rotacion acumulada

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // bloquea el raton en el centro
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // controles (raton)
        mouseX = Mouse.current.delta.x.ReadValue() * sensitivity * Time.deltaTime;
        mouseY = Mouse.current.delta.y.ReadValue() * sensitivity * Time.deltaTime;

        // acumulacion de la rotacion arriba/abajo
        xRotation -= mouseY;

        // limita la rotacion
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // aplica la rotacionm 
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // camara
        playerbody.Rotate(Vector3.up * mouseX); // jugador



    }
}

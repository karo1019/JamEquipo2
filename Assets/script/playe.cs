using UnityEngine;
using UnityEngine.InputSystem; // nuevo sistema :p

public class playe : MonoBehaviour
{
   
    public static int interactionCounter; //Para contar los objetos con los q el jugador ha interactuado
    public static int badinteractionCounter; //Para contar los objetos que te mandan a final malo/todavia 
    public static int KeyinteractionCounter; //Para desbloquear puertas, igual creo esta facil si tienen orden solo es ponerle if > numerodellave se desbloquea puerta?

    public float velocidad; // velocidad de movimiento del jugador

    private Vector2 moveInput; // nueva forma de guardar el input del teclado 
  
    private Rigidbody rb;

    public Transform camarabody; // referencia a la camara del jugador


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

        //El jugador inicia con 0 llaves
        KeyinteractionCounter = 0;

        // otener el componente del jugador
        rb = GetComponent<Rigidbody>();

        // evitar q el personaje se voltee al chocar
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        // controles (teclado)
        if (Keyboard.current != null)
        {
            moveInput = new Vector2(
                (Keyboard.current.dKey.isPressed ? 1 : 0) - (Keyboard.current.aKey.isPressed ? 1 : 0),
                (Keyboard.current.wKey.isPressed ? 1 : 0) - (Keyboard.current.sKey.isPressed ? 1 : 0)
            );
        }

    }

    void FixedUpdate()
    {

        // direccion respecto a la camara
        Vector3 forward = camarabody.forward;
        Vector3 right = camarabody.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        // combierte a vector de movimiento 
        Vector3 moveDirection = (forward * moveInput.y + right * moveInput.x) * velocidad;

        // movimiento del jugador respetando fisica
        rb.MovePosition(transform.position + moveDirection * Time.fixedDeltaTime);

        if (DialogManager.Instance != null && DialogManager.Instance.IsDialogActive())
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
        else
        {
            rb.constraints = RigidbodyConstraints.None;
            rb.freezeRotation = true;
        }

    }

}

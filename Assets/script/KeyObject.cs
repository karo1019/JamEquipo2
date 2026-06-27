using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class KeyObjeto : MonoBehaviour
{
    [SerializeField] private bool esPuerta;
    [SerializeField] private GameObject ObjectToInteractKEY;
    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject dialoguePabel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(4, 6)] private string[] dialogueLines;
    private bool isPlayerInRange;
    private bool didDialogueStart;
    public float textSpeed;
    private int index;
    private bool isTyping = false;
    private bool playerHasInteracted;
    public AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHasInteracted = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E)) // Solo si el jugador esta en el rango y presiona E la interaccion continua
        {
            if (!didDialogueStart)
            {
                if (!DialogManager.Instance.IsDialogActive())
                {
                    StartDialogue();
                }
            }
            else if (isTyping) // skip de linea
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[index];
                isTyping = false;
            }
            else
            {
                NextLine();
            }

        }
    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        Debug.Log(playe.KeyinteractionCounter);
        dialoguePabel.SetActive(true);
        dialogueMark.SetActive(false);
        DialogManager.Instance.OpenDialog(dialoguePabel);
        index = 0;
        StartCoroutine(Typeline());
        audioSource.Play();
    }
    private void OnTriggerEnter(Collider collision) // Muestra la marca para interactuar
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            dialogueMark.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider collision) //Esconde la marca
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialogueMark.SetActive(false);
        }
    }

    IEnumerator Typeline()
    {
        isTyping = true;
        dialogueText.text = string.Empty;

        foreach (char c in dialogueLines[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false; // termino de escribir
    }

    private void NextLine()
    {
        if (index < dialogueLines.Length - 1)
        {
            index++;
            StartCoroutine(Typeline());
        }
        else
        {
            didDialogueStart = false;
            DialogManager.Instance.CloseDialog();
            dialogueMark.SetActive(true);
            audioSource.Stop();
            if (!playerHasInteracted && !esPuerta)
            {
                ObjectToInteractKEY.SetActive(false);
                ++playe.KeyinteractionCounter;
                playerHasInteracted = true;
            }
        }
    }
}

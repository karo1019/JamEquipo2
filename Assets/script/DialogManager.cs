using UnityEngine;
public class DialogManager : MonoBehaviour
{
    public static DialogManager Instance;
    private GameObject currentDialog;

    void Awake()
    {
        // Singleton para accederlo desde cualquier script
        if (Instance == null) Instance = this;
    }

    public bool IsDialogActive() 
    {
        return currentDialog != null && currentDialog.activeSelf;
    }

    public void OpenDialog(GameObject dialogPanel)
    {
        if (IsDialogActive()) return; // ya hay uno abierto

        currentDialog = dialogPanel;
        currentDialog.SetActive(true);
    }

    public void CloseDialog()
    {
        if (currentDialog != null)
        {
            currentDialog.SetActive(false);
            currentDialog = null;
        }
    }
}

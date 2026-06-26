using UnityEngine;

public class List : MonoBehaviour
{

    // referencias 
    public GameObject tache;
    public GameObject tache1;
    public GameObject tache2;
    public GameObject tache3;
    public GameObject tache4;
    public GameObject tache5;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // esconde los taches de la lista
        if (tache != null)
        {
            tache.SetActive(false);
            tache1.SetActive(false);
            tache2.SetActive(false);
            tache3.SetActive(false);
            tache4.SetActive(false);
            tache5.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

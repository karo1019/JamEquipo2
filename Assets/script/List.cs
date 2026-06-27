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

    [SerializeField] private DialogObjeto dialogoObjeto; // referencia al scrip de onjeto

    private int contadorObjetos = 0; // rejistra los objetos de valor

    // probabilidad de ser de valor
    [SerializeField, Range(0f, 1f)] private float probabilidadDeValor = 0.3f; // 30%

    public GameObject Victori; // refrerencia al canva de victoria


    // Start
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

        // eventarse a todos los onjetos
        DialogObjeto[] dialogos = FindObjectsOfType<DialogObjeto>();

        foreach (DialogObjeto d in dialogos)
        {
            d.OnObjetoInteractuado += Valorar;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // asigna un valor al objeto recojido de forma aleatoria 
    private void Valorar()
    {
        int res = (Random.value < probabilidadDeValor) ? 1 : 0; // da valor entre 0 y 1 con preferencia a 0

        if (res == 1)
        {
            contadorObjetos++;

            switch (contadorObjetos)
            {
                case 1: tache.SetActive(true);
                    break;
                case 2:
                    tache1.SetActive(true);
                    break;
                case 3:
                    tache2.SetActive(true);
                    break;
                case 4:
                    tache3.SetActive(true);
                    break;
                case 5:
                    tache4.SetActive(true);
                    break;
                case 6:
                    tache5.SetActive(true);

                    // aparece el canva de victoria
                    if(Victori != null)
                    {
                        Victori.SetActive(true);
                    }
                    break;
            }
        }
    }

        // desenventarse de todos los objetos
     void OnDestroy()
    {
        DialogObjeto[] dialogos = FindObjectsOfType<DialogObjeto>();
        foreach (DialogObjeto d in dialogos)
        {
            d.OnObjetoInteractuado -= Valorar;
        }
    }
}

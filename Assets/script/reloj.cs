using UnityEngine;
using TMPro; // para el texto

public class reloj : MonoBehaviour
{
    // simulacion del tiempo
    public float duracion = 120f; // 120s = 2 minutos

    public TextMeshProUGUI relojText; // referencia al texto

    private float tiempoTrancurrido;
    private float progreso;
    private float horasTotal;
    private int horas;
    private int minutos;

    public GameObject GameOver_final; // referencia al final por tiempo


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // esconde el canva q no se ve
        if (GameOver_final != null)
        {
            GameOver_final.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // tiempo real
        tiempoTrancurrido += Time.deltaTime;

        // progreso 
        progreso = tiempoTrancurrido / duracion;

        // progreso a horastotal
        horasTotal = 24f - (progreso * 24f);

        // enteros
        horas = Mathf.FloorToInt(horasTotal);
        minutos = Mathf.FloorToInt((horasTotal - horas) * 60f);

        // formato horal
        relojText.text = string.Format("{0:00}:{1:00}", horas, minutos);

        // fin del tiempo
        if (tiempoTrancurrido >= duracion)
        {
            // muerte
            // canva de perdida por tiempo
            if (GameOver_final != null)
            {
                GameOver_final.SetActive(true);
            }

            // parar reloj
            enabled = false;
        }
    }
}

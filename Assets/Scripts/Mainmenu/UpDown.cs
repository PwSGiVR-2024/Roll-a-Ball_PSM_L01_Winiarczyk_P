using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    // Amplituda ruchu w g�r� i w d�
    public float amplitude = 0.5f;

    // Cz�stotliwo�� ruchu
    public float frequency = 1f;

    // Pocz�tkowa pozycja obiektu
    private Vector3 startPosition;

    void Start()
    {
        // Zapami�tanie pocz�tkowej pozycji obiektu
        startPosition = transform.position;
    }

    void Update()
    {
        // Obliczenie przesuni�cia na osi Y w zale�no�ci od funkcji sinus
        float offsetY = Mathf.Sin(Time.time * frequency) * amplitude;

        // Aktualizacja pozycji obiektu
        transform.position = new Vector3(startPosition.x, startPosition.y + offsetY, startPosition.z);
    }
}


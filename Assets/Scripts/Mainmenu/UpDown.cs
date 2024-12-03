using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    // Amplituda ruchu w górê i w dó³
    public float amplitude = 0.5f;

    // Czêstotliwoœæ ruchu
    public float frequency = 1f;

    // Pocz¹tkowa pozycja obiektu
    private Vector3 startPosition;

    void Start()
    {
        // Zapamiêtanie pocz¹tkowej pozycji obiektu
        startPosition = transform.position;
    }

    void Update()
    {
        // Obliczenie przesuniêcia na osi Y w zale¿noœci od funkcji sinus
        float offsetY = Mathf.Sin(Time.time * frequency) * amplitude;

        // Aktualizacja pozycji obiektu
        transform.position = new Vector3(startPosition.x, startPosition.y + offsetY, startPosition.z);
    }
}


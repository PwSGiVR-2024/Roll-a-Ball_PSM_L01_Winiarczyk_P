using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    // Amplituda ruchu w górę i w dół
    public float amplitude = 0.5f;

    // Częstotliwość ruchu
    public float frequency = 1f;

    // Początkowa pozycja obiektu
    private Vector3 startPosition;

    void Start()
    {
        // Zapamiętanie początkowej pozycji obiektu
        startPosition = transform.position;
    }

    void Update()
    {
        // Obliczenie przesunięcia na osi Y w zależności od funkcji sinus
        float offsetY = Mathf.Sin(Time.time * frequency) * amplitude;

        // Aktualizacja pozycji obiektu
        transform.position = new Vector3(startPosition.x, startPosition.y + offsetY, startPosition.z);
    }
}


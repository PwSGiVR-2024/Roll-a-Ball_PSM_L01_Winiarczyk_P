using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    // Okre�lenie pr�dko�ci przemieszczania si� obiektu
    public float speed = 2;

    // Minimalna warto�� wsp�rz�dnej x, do kt�rej obiekt mo�e si� przemie�ci�, potem musi zawr�ci�
    public float minX = -3;
    // Maksymalna warto�� wsp�rz�dnej x, do kt�rej obiekt mo�e si� przemie�ci�, potem musi zawr�ci�
    public float maxX = 3;

    // Zmienna przechowuje aktualny kierunek ruchu. Je�eli obiekt porusza si� w lewo, to przyjmuje warto�� true
    private bool left = false;

    void Update()
    {
        // Odczytanie aktualnego po�o�enia obiektu
        Vector3 v = transform.position;

        // Okre�lenie drogi przebytej przez obiekt podczas ruchu na podstawie jego pr�dko�ci i czasu jaki up�yn�� od wyrysowania ostatniej klatki
        float sx = speed * Time.deltaTime;

        // Sprawdzenie kierunku ruchu obiektu
        if (left)
        {
            // Je�eli obiekt ma porusza� si� w lewo, to warto�� wsp�rz�dnej x po�o�enia obiektu jest zmniejszana
            v.x = v.x - sx;
            // Sprawdzenie czy obiekt dotar� do lewej granicy obszaru, po kt�rym si� porusza
            if (v.x <= minX)
            {
                // Wpisanie po�o�enia lewej granicy jako wsp�rz�dnej x obiektu (na wypadek gdyby by� ju� za t� granic�)
                v.x = minX;
                // Zmiana kierunku ruchu na w prawo
                left = false;
            }
        }
        else
        {
            // Je�eli obiekt ma porusza� si� w prawo, to warto�� wsp�rz�dnej x po�o�enia obiektu jest zwi�kszana
            v.x = v.x + sx;
            // Sprawdzenie czy obiekt dotar� do prawej granicy obszaru, po kt�rym si� porusza
            if (v.x >= maxX)
            {
                // Wpisanie po�o�enia prawej granicy jako wsp�rz�dnej x obiektu (na wypadek gdyby by� ju� za t� granic�)
                v.x = maxX;
                // Zmiana kierunku ruchu na w lewo
                left = true;
            }
        }

        // Zaktualizowanie po�o�enia obiektu
        transform.position = v;
    }
}
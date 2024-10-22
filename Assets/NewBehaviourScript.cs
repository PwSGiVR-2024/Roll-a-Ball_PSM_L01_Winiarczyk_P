using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    // Okreœlenie prêdkoœci przemieszczania siê obiektu
    public float speed = 2;

    // Minimalna wartoœæ wspó³rzêdnej x, do której obiekt mo¿e siê przemieœciæ, potem musi zawróciæ
    public float minX = -3;
    // Maksymalna wartoœæ wspó³rzêdnej x, do której obiekt mo¿e siê przemieœciæ, potem musi zawróciæ
    public float maxX = 3;

    // Zmienna przechowuje aktualny kierunek ruchu. Je¿eli obiekt porusza siê w lewo, to przyjmuje wartoœæ true
    private bool left = false;

    void Update()
    {
        // Odczytanie aktualnego po³o¿enia obiektu
        Vector3 v = transform.position;

        // Okreœlenie drogi przebytej przez obiekt podczas ruchu na podstawie jego prêdkoœci i czasu jaki up³yn¹³ od wyrysowania ostatniej klatki
        float sx = speed * Time.deltaTime;

        // Sprawdzenie kierunku ruchu obiektu
        if (left)
        {
            // Je¿eli obiekt ma poruszaæ siê w lewo, to wartoœæ wspó³rzêdnej x po³o¿enia obiektu jest zmniejszana
            v.x = v.x - sx;
            // Sprawdzenie czy obiekt dotar³ do lewej granicy obszaru, po którym siê porusza
            if (v.x <= minX)
            {
                // Wpisanie po³o¿enia lewej granicy jako wspó³rzêdnej x obiektu (na wypadek gdyby by³ ju¿ za t¹ granic¹)
                v.x = minX;
                // Zmiana kierunku ruchu na w prawo
                left = false;
            }
        }
        else
        {
            // Je¿eli obiekt ma poruszaæ siê w prawo, to wartoœæ wspó³rzêdnej x po³o¿enia obiektu jest zwiêkszana
            v.x = v.x + sx;
            // Sprawdzenie czy obiekt dotar³ do prawej granicy obszaru, po którym siê porusza
            if (v.x >= maxX)
            {
                // Wpisanie po³o¿enia prawej granicy jako wspó³rzêdnej x obiektu (na wypadek gdyby by³ ju¿ za t¹ granic¹)
                v.x = maxX;
                // Zmiana kierunku ruchu na w lewo
                left = true;
            }
        }

        // Zaktualizowanie po³o¿enia obiektu
        transform.position = v;
    }
}
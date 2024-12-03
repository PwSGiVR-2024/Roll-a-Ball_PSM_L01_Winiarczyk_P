using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    // Okre�lenie pr�dko�ci obrotu obiektu
    public float speed = 50;

    void Start()
    {
        // Ustawienie pocz�tkowego nachylenia -38 stopni na osi Z
        transform.rotation = Quaternion.Euler(0, 0, -38);
    }

    void Update()
    {
        // Obr�t wok� lokalnej osi Y
        float angle = speed * Time.deltaTime;

        // Obracanie obiektu wok� jego lokalnej osi Y
        transform.Rotate(0, angle, 0, Space.Self);
    }
}

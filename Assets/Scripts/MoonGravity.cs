using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonGravity : MonoBehaviour
{
    public GameObject moon; // Obiekt Ksi�yca
    public float gravityStrength = 10f; // Si�a grawitacji (dostosuj w zale�no�ci od potrzeb)
    public float surfaceGravityStrength = 5f; // Si�a grawitacji przy powierzchni ksi�yca
    public float minDistanceToSurface = 1f; // Minimalna odleg�o�� od powierzchni ksi�yca, by nie odpada�
    public float maxDistanceToSurface = 10f; // Maksymalna odleg�o��, na jakiej ma dzia�a� grawitacja

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // Pobieramy komponent Rigidbody gracza
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Obliczanie wektora przyci�gania (si�a grawitacji)
        Vector3 gravityDirection = moon.transform.position - transform.position; // Kierunek do Ksi�yca
        float distance = gravityDirection.magnitude; // Odleg�o�� mi�dzy gracza a Ksi�ycem

        // Je�li gracz znajduje si� bardzo blisko ksi�yca, wyhamowujemy spadanie
        if (distance < minDistanceToSurface)
        {
            gravityDirection.Normalize();
            rb.AddForce(gravityDirection * surfaceGravityStrength, ForceMode.Acceleration);
        }
        else
        {
            // Je�li gracz jest w odpowiedniej odleg�o�ci od ksi�yca, przyci�gamy go z si�� grawitacyjn�
            gravityDirection.Normalize();

            // Obliczanie si�y grawitacji w zale�no�ci od odleg�o�ci
            float gravityForce = gravityStrength / (distance * distance); // Si�a maleje z kwadratem odleg�o�ci

            // Zastosowanie si�y grawitacji
            rb.AddForce(gravityDirection * gravityForce, ForceMode.Acceleration);
        }

        // Zapewniamy, �e gracz nie odleci w kosmosie (ograniczenie maksymalnej odleg�o�ci od ksi�yca)
        if (distance > maxDistanceToSurface)
        {
            // W tym przypadku mo�e by� te� sens zaimplementowa� mechanizm powrotu do powierzchni Ksi�yca
            gravityDirection.Normalize();
            rb.AddForce(gravityDirection * gravityStrength, ForceMode.Acceleration);
        }
    }
}

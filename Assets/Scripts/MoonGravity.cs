using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonGravity : MonoBehaviour
{
    public GameObject moon; // Obiekt Ksiê¿yca
    public float gravityStrength = 10f; // Si³a grawitacji (dostosuj w zale¿noœci od potrzeb)
    public float surfaceGravityStrength = 5f; // Si³a grawitacji przy powierzchni ksiê¿yca
    public float minDistanceToSurface = 1f; // Minimalna odleg³oœæ od powierzchni ksiê¿yca, by nie odpadaæ
    public float maxDistanceToSurface = 10f; // Maksymalna odleg³oœæ, na jakiej ma dzia³aæ grawitacja

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
        // Obliczanie wektora przyci¹gania (si³a grawitacji)
        Vector3 gravityDirection = moon.transform.position - transform.position; // Kierunek do Ksiê¿yca
        float distance = gravityDirection.magnitude; // Odleg³oœæ miêdzy gracza a Ksiê¿ycem

        // Jeœli gracz znajduje siê bardzo blisko ksiê¿yca, wyhamowujemy spadanie
        if (distance < minDistanceToSurface)
        {
            gravityDirection.Normalize();
            rb.AddForce(gravityDirection * surfaceGravityStrength, ForceMode.Acceleration);
        }
        else
        {
            // Jeœli gracz jest w odpowiedniej odleg³oœci od ksiê¿yca, przyci¹gamy go z si³¹ grawitacyjn¹
            gravityDirection.Normalize();

            // Obliczanie si³y grawitacji w zale¿noœci od odleg³oœci
            float gravityForce = gravityStrength / (distance * distance); // Si³a maleje z kwadratem odleg³oœci

            // Zastosowanie si³y grawitacji
            rb.AddForce(gravityDirection * gravityForce, ForceMode.Acceleration);
        }

        // Zapewniamy, ¿e gracz nie odleci w kosmosie (ograniczenie maksymalnej odleg³oœci od ksiê¿yca)
        if (distance > maxDistanceToSurface)
        {
            // W tym przypadku mo¿e byæ te¿ sens zaimplementowaæ mechanizm powrotu do powierzchni Ksiê¿yca
            gravityDirection.Normalize();
            rb.AddForce(gravityDirection * gravityStrength, ForceMode.Acceleration);
        }
    }
}

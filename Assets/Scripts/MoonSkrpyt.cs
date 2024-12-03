using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonSkrypt : MonoBehaviour
{
    public float gravityStrength = 9.8f; // Si�a przyci�gania Ksi�yca
    public Transform player; // Gracz (sfera)

    void FixedUpdate()
    {
        // Obliczanie si�y przyci�gania
        Vector3 direction = (transform.position - player.position).normalized; // Kierunek do Ksi�yca
        Vector3 gravity = direction * gravityStrength; // Si�a przyci�gania

        // Dodanie si�y do gracza, by go przyci�gn��
        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(gravity, ForceMode.Acceleration);
        }
    }
}

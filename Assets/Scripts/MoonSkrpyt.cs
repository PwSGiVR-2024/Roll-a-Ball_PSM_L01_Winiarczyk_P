using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonSkrypt : MonoBehaviour
{
    public float gravityStrength = 9.8f; // Si³a przyci¹gania Ksiê¿yca
    public Transform player; // Gracz (sfera)

    void FixedUpdate()
    {
        // Obliczanie si³y przyci¹gania
        Vector3 direction = (transform.position - player.position).normalized; // Kierunek do Ksiê¿yca
        Vector3 gravity = direction * gravityStrength; // Si³a przyci¹gania

        // Dodanie si³y do gracza, by go przyci¹gn¹æ
        Rigidbody rb = player.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(gravity, ForceMode.Acceleration);
        }
    }
}

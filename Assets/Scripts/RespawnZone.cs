using UnityEngine;

public class RespawnZone : MonoBehaviour
{
    [Header("Respawn Position")]
    public Transform respawnPoint; // Punkt, do którego gracz ma być teleportowany.

    private void OnTriggerEnter(Collider other)
    {
        // Sprawdzamy, czy obiekt, który wszedł w strefę, jest graczem (lub ma odpowiedni tag)
        if (other.CompareTag("Player"))
        {
            // Teleportujemy gracza na pozycję respawnPoint
            other.transform.position = respawnPoint.position;

            // Opcjonalnie: Możesz zresetować prędkość gracza, jeśli używasz Rigidbody
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero; // Zatrzymujemy ruch gracza
            }
        }
    }
}

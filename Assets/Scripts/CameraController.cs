using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player; // Gracz (sfera)
    public float followDistance = 6f; // Zmniejszona odleg³oœæ kamery od gracza
    public float heightOffset = 3f; // Wysokoœæ kamery nad graczem
    public float followSpeed = 5f; // Szybkoœæ pod¹¿ania kamery za graczem
    public float rotationSpeed = 100f; // Szybkoœæ obrotu kamery wokó³ gracza

    private float currentAngle = 0f; // Aktualny k¹t obrotu kamery wokó³ gracza
    private float minDistance = 4f; // Minimalna odleg³oœæ kamery od gracza, aby nie wesz³a w powierzchniê Ksiê¿yca

    void LateUpdate()
    {
        // Obliczanie nowej pozycji kamery wokó³ gracza
        Vector3 offset = new Vector3(0, heightOffset, -followDistance); // Ustawienie kamery
        Vector3 targetPosition = player.transform.position + offset;

        // Zastosowanie rotacji wokó³ gracza
        Quaternion rotation = Quaternion.Euler(0, currentAngle, 0); // Obrót w osi Y
        targetPosition = player.transform.position + rotation * offset; // Zastosowanie rotacji

        // Dostosowanie pozycji kamery, aby nie by³a za blisko Ksiê¿yca
        if (Vector3.Distance(targetPosition, player.transform.position) < minDistance)
        {
            targetPosition = player.transform.position + offset.normalized * minDistance;
        }

        // P³ynne przesuniêcie kamery do docelowej pozycji
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // Kamera zawsze patrzy na gracza
        transform.LookAt(player.transform.position);

        // Obs³uga obrotu kamery wokó³ gracza za pomoc¹ klawiszy
        if (Input.GetKey(KeyCode.Q))
        {
            currentAngle -= rotationSpeed * Time.deltaTime; // Obrót w lewo
        }
        if (Input.GetKey(KeyCode.E))
        {
            currentAngle += rotationSpeed * Time.deltaTime; // Obrót w prawo
        }
    }
}

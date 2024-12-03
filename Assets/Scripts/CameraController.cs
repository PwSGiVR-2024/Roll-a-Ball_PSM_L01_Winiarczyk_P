using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player; // Gracz (sfera)
    public float followDistance = 6f; // Zmniejszona odleg�o�� kamery od gracza
    public float heightOffset = 3f; // Wysoko�� kamery nad graczem
    public float followSpeed = 5f; // Szybko�� pod��ania kamery za graczem
    public float rotationSpeed = 100f; // Szybko�� obrotu kamery wok� gracza

    private float currentAngle = 0f; // Aktualny k�t obrotu kamery wok� gracza
    private float minDistance = 4f; // Minimalna odleg�o�� kamery od gracza, aby nie wesz�a w powierzchni� Ksi�yca

    void LateUpdate()
    {
        // Obliczanie nowej pozycji kamery wok� gracza
        Vector3 offset = new Vector3(0, heightOffset, -followDistance); // Ustawienie kamery
        Vector3 targetPosition = player.transform.position + offset;

        // Zastosowanie rotacji wok� gracza
        Quaternion rotation = Quaternion.Euler(0, currentAngle, 0); // Obr�t w osi Y
        targetPosition = player.transform.position + rotation * offset; // Zastosowanie rotacji

        // Dostosowanie pozycji kamery, aby nie by�a za blisko Ksi�yca
        if (Vector3.Distance(targetPosition, player.transform.position) < minDistance)
        {
            targetPosition = player.transform.position + offset.normalized * minDistance;
        }

        // P�ynne przesuni�cie kamery do docelowej pozycji
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // Kamera zawsze patrzy na gracza
        transform.LookAt(player.transform.position);

        // Obs�uga obrotu kamery wok� gracza za pomoc� klawiszy
        if (Input.GetKey(KeyCode.Q))
        {
            currentAngle -= rotationSpeed * Time.deltaTime; // Obr�t w lewo
        }
        if (Input.GetKey(KeyCode.E))
        {
            currentAngle += rotationSpeed * Time.deltaTime; // Obr�t w prawo
        }
    }
}

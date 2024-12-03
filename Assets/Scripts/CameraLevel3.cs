using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLevel3 : MonoBehaviour
{
    public GameObject player; // Gracz (sfera)
    public float followDistance = 6f; // Odleg�o�� kamery od gracza (poziomo)
    public float height = 10f; // Sta�a wysoko�� kamery nad graczem

    void LateUpdate()
    {
        // Ustawiamy pozycj� kamery zawsze nad graczem, nie zale�nie od rotacji gracza
        Vector3 targetPosition = player.transform.position + Vector3.up * height - player.transform.forward * followDistance;

        // Zmieniamy pozycj� kamery tylko w osi X i Z (poziom)
        targetPosition.y = player.transform.position.y + height;  // Sta�a wysoko�� nad graczem

        // Ustawienie pozycji kamery
        transform.position = targetPosition;

        // Kamera zawsze patrzy na gracza
        transform.LookAt(player.transform.position);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLevel3 : MonoBehaviour
{
    public GameObject player; // Gracz (sfera)
    public float followDistance = 6f; // Odleg³oœæ kamery od gracza (poziomo)
    public float height = 10f; // Sta³a wysokoœæ kamery nad graczem

    void LateUpdate()
    {
        // Ustawiamy pozycjê kamery zawsze nad graczem, nie zale¿nie od rotacji gracza
        Vector3 targetPosition = player.transform.position + Vector3.up * height - player.transform.forward * followDistance;

        // Zmieniamy pozycjê kamery tylko w osi X i Z (poziom)
        targetPosition.y = player.transform.position.y + height;  // Sta³a wysokoœæ nad graczem

        // Ustawienie pozycji kamery
        transform.position = targetPosition;

        // Kamera zawsze patrzy na gracza
        transform.LookAt(player.transform.position);
    }
}

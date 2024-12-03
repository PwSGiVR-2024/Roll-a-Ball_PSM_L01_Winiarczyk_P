using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public float jumpForce = 5f; // Si�a skoku
    private bool isGrounded = false; // Zmienna przechowuj�ca informacj�, czy gracz jest na ziemi
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Pobierz komponent Rigidbody
    }

    void Update()
    {
        // Sprawdzanie, czy gracz nacisn�� spacj� i czy jest na ziemi
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    // Funkcja skoku
    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Dodajemy si�� skoku do Rigidbody
    }

    // Detekcja kolizji z ziemi�
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Sprawdzamy, czy gracz dotkn�� obiektu o tagu "Ground"
        {
            isGrounded = true; // Gracz jest na ziemi
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Sprawdzamy, czy gracz opu�ci� ziemi�
        {
            isGrounded = false; // Gracz nie jest na ziemi
        }
    }
}

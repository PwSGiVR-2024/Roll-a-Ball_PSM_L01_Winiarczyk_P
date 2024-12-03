using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    public float jumpForce = 5f; // Si³a skoku
    private bool isGrounded = false; // Zmienna przechowuj¹ca informacjê, czy gracz jest na ziemi
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Pobierz komponent Rigidbody
    }

    void Update()
    {
        // Sprawdzanie, czy gracz nacisn¹³ spacjê i czy jest na ziemi
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    // Funkcja skoku
    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Dodajemy si³ê skoku do Rigidbody
    }

    // Detekcja kolizji z ziemi¹
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Sprawdzamy, czy gracz dotkn¹³ obiektu o tagu "Ground"
        {
            isGrounded = true; // Gracz jest na ziemi
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground")) // Sprawdzamy, czy gracz opuœci³ ziemiê
        {
            isGrounded = false; // Gracz nie jest na ziemi
        }
    }
}

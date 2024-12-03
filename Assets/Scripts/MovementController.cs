using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementController : MonoBehaviour
{
    public Text scoreText, Uwon;
    public GameObject NLB;
    public int score;
    public float thrust = 20f; // Si�a poruszania si�
    public Camera playerCamera; // Odwo�anie do kamery
    private Rigidbody rb;

    private JumpController jumpController; // Referencja do skryptu JumpController

    // Start is called before the first frame update
    void Start()
    {
        // Pobierz komponent Rigidbody
        rb = GetComponent<Rigidbody>();

        // Ukryj przycisk NLB na starcie gry
        NLB.gameObject.SetActive(false);

        // Pobierz komponent JumpController
        jumpController = GetComponent<JumpController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Masz zebrane:" + score);
        }
    }

    public void CollectScore()
    {
        score++;
        scoreText.text = "Score: " + score;

        if (score >= 7)
        {
            Uwon.text = "You've won!";
            NLB.gameObject.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        // Oblicz kierunki poruszania si� w zale�no�ci od k�ta kamery
        Vector3 forward = playerCamera.transform.forward; // Kierunek do przodu kamery
        forward.y = 0f; // Usuwamy ruch w g�r� i w d�, aby porusza� si� tylko w poziomie
        forward.Normalize(); // Normalizujemy wektor, aby mia� jednostkow� d�ugo��

        Vector3 right = playerCamera.transform.right; // Kierunek w prawo kamery
        right.y = 0f; // Usuwamy ruch w g�r� i w d�
        right.Normalize(); // Normalizujemy wektor

        // Logika sterowania ruchem
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(forward * thrust); // Poruszamy si� w kierunku, w kt�rym patrzy kamera
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-forward * thrust); // Poruszamy si� w przeciwnym kierunku
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-right * thrust); // Poruszamy si� w lewo wzgl�dem kamery
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(right * thrust); // Poruszamy si� w prawo wzgl�dem kamery
        }
    }
}

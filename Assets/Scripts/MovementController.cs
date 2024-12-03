using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementController : MonoBehaviour
{
    public Text scoreText, Uwon;
    public GameObject NLB;
    public int score;
    public float thrust = 20f; // Si³a poruszania siê
    public Camera playerCamera; // Odwo³anie do kamery
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
        // Oblicz kierunki poruszania siê w zale¿noœci od k¹ta kamery
        Vector3 forward = playerCamera.transform.forward; // Kierunek do przodu kamery
        forward.y = 0f; // Usuwamy ruch w górê i w dó³, aby poruszaæ siê tylko w poziomie
        forward.Normalize(); // Normalizujemy wektor, aby mia³ jednostkow¹ d³ugoœæ

        Vector3 right = playerCamera.transform.right; // Kierunek w prawo kamery
        right.y = 0f; // Usuwamy ruch w górê i w dó³
        right.Normalize(); // Normalizujemy wektor

        // Logika sterowania ruchem
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(forward * thrust); // Poruszamy siê w kierunku, w którym patrzy kamera
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-forward * thrust); // Poruszamy siê w przeciwnym kierunku
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-right * thrust); // Poruszamy siê w lewo wzglêdem kamery
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(right * thrust); // Poruszamy siê w prawo wzglêdem kamery
        }
    }
}

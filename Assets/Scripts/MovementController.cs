using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovementController : MonoBehaviour
{



    public Text scoreText, Uwon;
    public GameObject NLB;
    public int score;
    public float thrust = 20;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // Pobierz komponent Rigidbody z GameObjectu, do którego jest przypiêty ten skrypt
        rb = GetComponent<Rigidbody>();

        // Ukryj przycisk NLB na starcie gry
        NLB.gameObject.SetActive(false);
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
        // Logika sterowania ruchem
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector3.forward * thrust);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector3.back * thrust);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * thrust);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * thrust);
        }
    }
}

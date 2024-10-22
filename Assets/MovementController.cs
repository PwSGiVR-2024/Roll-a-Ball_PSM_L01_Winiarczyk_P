using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MovementController : MonoBehaviour
{
    public Text scoreText, Uwon;
    public int score;
    public float thrust =20;
    private Rigidbody rb;



    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Masz zebrane:" + score);

        }

        if (score >= 7)
        {
            Debug.Log("Wygra³eœ!");
            score = 0;
        }
       

    }
    public void CollectScore()
    {
        score++;
        scoreText.text = "Score: " + score;
        if (score >= 7)
        {
            Uwon.text = "You've won!";
        }

    }
  
    private void FixedUpdate()
    {
      


        if (Input.GetKey(KeyCode.W))
        {
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            rb.AddForce(Vector3.forward * thrust);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            rb.AddForce(Vector3.back * thrust);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            rb.AddForce(Vector3.left * thrust);
        }


        if (Input.GetKey(KeyCode.D))
        {
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            rb.AddForce(Vector3.right * thrust);
        }
    }


   
}


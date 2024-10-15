using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MovementController : MonoBehaviour
{
    public int score = 0;
    Rigidbody m_Rigidbody;
    public float thrust =20;
    private Rigidbody rb;



    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Masz zebrane:" + score);
        }


        if (Input.GetKey(KeyCode.W))
        {
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            m_Rigidbody.AddForce(0, 0, thrust);
        }
        if (Input.GetKey(KeyCode.S))
        {
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            m_Rigidbody.AddForce(0, 0, (-thrust));
        }
        if (Input.GetKey(KeyCode.A))
        {
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            m_Rigidbody.AddForce((-thrust), 0, 0);
        }


        if (Input.GetKey(KeyCode.D))
        {
            //Apply a force to this Rigidbody in direction of this GameObjects up axis
            m_Rigidbody.AddForce(thrust, 0, 0);
        }
    }

   
}


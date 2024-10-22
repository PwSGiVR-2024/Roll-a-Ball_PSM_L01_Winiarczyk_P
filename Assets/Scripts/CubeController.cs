using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField]
    Vector3 forceValue;

    [SerializeField]
    bool reactOnContact;
    [SerializeField]
    bool reactInside;

    [SerializeField]
    float forceMultiplier;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(reactOnContact) rb.AddForce(forceValue, ForceMode.Impulse);
    }


    private void OnTriggerStay(Collider other)
    {
        if (reactInside)
        {
            Vector3 forceVector = Vector3.up * Mathf.Abs(other.bounds.max.y - transform.position.y) * forceMultiplier;

            Ray ray = new Ray(transform.position,  forceVector);
            Debug.DrawRay(ray.origin, forceVector/10, Color.red);

            rb.AddForce(forceVector);
        }
    }

}

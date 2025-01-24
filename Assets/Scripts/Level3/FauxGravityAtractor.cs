using UnityEngine;
using System.Collections;

public class FauxGravityAtractor : MonoBehaviour
{
    public float gravity = -10;

    public void Attract(Transform body)
    {
        Vector3 gravityUp = (body.position - transform.position).normalized;
        Vector3 bodyup = body.up;

        body.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);

        
        Quaternion targetRotation = Quaternion.FromToRotation(bodyup, gravityUp) * body.rotation;
        body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 50 * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField]
    GameObject cannonBall;

    [SerializeField]
    float force;

    [SerializeField]
    Camera mainCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            GameObject go = Instantiate(cannonBall, mainCamera.transform.position, Quaternion.identity);
            go.GetComponent<Rigidbody>().AddForce(ray.direction * force, ForceMode.Impulse); 
        }
    }
}

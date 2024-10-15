using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Collectible : MonoBehaviour
{

    private void OnTriggerEnter(Collider collision)
    {
        collision.gameObject.GetComponent<MovementController>().score += 1;
        Debug.Log("Zdoby³eœ punk!");
        gameObject.SetActive(false);
    }

 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 20 * Time.deltaTime, 0);
    }
}

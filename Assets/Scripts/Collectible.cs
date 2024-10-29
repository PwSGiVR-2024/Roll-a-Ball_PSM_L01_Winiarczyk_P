using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Collectible : MonoBehaviour
{
    public AudioSource retrocoin;

    private void OnTriggerEnter(Collider collision)
    {
        retrocoin.Play();
        collision.gameObject.GetComponent<MovementController>().CollectScore();
        
        Debug.Log("Zdoby³eœ punk!");
        Invoke("Test", 0.3f);



    }
    private void Test()
    {
        gameObject.SetActive(false);
    }
   
 
    // Start is called before the first frame update
    void Start()
    {
        retrocoin = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(30,20,0) * Time.deltaTime);


    }
}

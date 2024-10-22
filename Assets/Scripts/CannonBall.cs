using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CannonBall : MonoBehaviour
{

    [SerializeField]
    int explosionForce;

    [SerializeField]
    int explosionRadius;

    [SerializeField]
    int explosionRange;

    [SerializeField]
    LayerMask layerMask;



    private void OnCollisionEnter(Collision collision)
    {
        StopAllCoroutines();
        StartCoroutine(BulletTime());

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRange, layerMask);

        Debug.Break();

        foreach (var item in colliders)
        {
            GetComponent<Rigidbody>()?.AddExplosionForce(explosionForce, transform.position, explosionRadius, 0, ForceMode.Impulse);
        }

        
        
    }

    

    IEnumerator BulletTime()
    {
        float timeScaleModifier = 0.2f;

        
        while(timeScaleModifier < 1)
        {
            Time.timeScale = timeScaleModifier;
            timeScaleModifier += 0.01f;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            yield return new WaitForSeconds(0.2f);
        }

        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;
    }


}

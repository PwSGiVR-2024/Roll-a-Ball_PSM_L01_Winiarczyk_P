using UnityEngine;

public class CollectibleLevel3 : MonoBehaviour
{
    public AudioSource retrocoin;

    private void OnTriggerEnter(Collider collision)
    {
        retrocoin.Play();

        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            player.CollectScoreLevel3(); // Wywo�aj metod� CollectScore w PlayerController
        }

        Debug.Log("Zdoby�e� punkt!");
        Invoke("DisableCollectible", 0.3f);
    }

    private void DisableCollectible()
    {
        gameObject.SetActive(false); // Dezaktywuj obiekt po zebraniu
    }

    void Start()
    {
        retrocoin = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.Rotate(new Vector3(0,25, 0) * Time.deltaTime); // Obr�t collectible
    }
}
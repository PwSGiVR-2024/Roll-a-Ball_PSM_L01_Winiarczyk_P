using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float movespeed = 15;
    public float sprintMultiplier = 2f; // Mnożnik prędkości podczas sprintu
    private Vector3 moveDir;
    public int score = 0; // Wynik gracza
    public Text scoreText; // Tekst do wyświetlania wyniku
    public Text Uwon; // Tekst do wyświetlania komunikatów
    public GameObject NLB; // Przycisk do przejścia na kolejny poziom

    public Light playerLight; // Komponent światła przypisany do gracza
    private bool isLightOn = false; // Flaga, czy światło jest włączone

    public TrailRenderer trailRenderer; // Trail Renderer dla efektu za graczem
    private bool isSprinting = false; // Flaga, czy gracz sprintuje
    private bool hasWon = false; // Flaga, czy gracz zdobył 7 punktów
    private bool reachedHome = false; // Flaga, czy gracz dotarł do rakiety

    void Start()
    {
        NLB?.SetActive(false); // Ukryj przycisk na starcie

        if (playerLight == null)
        {
            GameObject lightObject = new GameObject("PlayerLight");
            lightObject.transform.parent = transform;
            lightObject.transform.localPosition = Vector3.zero;
            playerLight = lightObject.AddComponent<Light>();
            playerLight.type = LightType.Point;
            playerLight.range = 10f;
            playerLight.intensity = 2f;
            playerLight.enabled = false;
        }

        if (trailRenderer == null)
        {
            trailRenderer = GetComponent<TrailRenderer>();
            if (trailRenderer == null)
            {
                Debug.LogError("TrailRenderer is not attached to the player! Please add it in the Inspector.");
            }
        }

        if (trailRenderer != null)
        {
            trailRenderer.enabled = false; // Na starcie wyłączony
        }

        if (Uwon != null)
        {
            Uwon.gameObject.SetActive(false); // Ukryj tekst na starcie
        }
    }

    void Update()
    {
        moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

        if (Input.GetKeyDown(KeyCode.F))
        {
            isLightOn = !isLightOn;
            playerLight.enabled = isLightOn;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
            if (trailRenderer != null)
            {
                trailRenderer.enabled = true;
            }
        }
        else
        {
            isSprinting = false;
            if (trailRenderer != null)
            {
                trailRenderer.enabled = false;
            }
        }
    }

    void FixedUpdate()
    {
        float currentSpeed = isSprinting ? movespeed * sprintMultiplier : movespeed;
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDir) * currentSpeed * Time.deltaTime);
    }

    public void CollectScoreLevel3()
    {
        score++;
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }

        if (score >= 7 && !hasWon)
        {
            hasWon = true; // Flaga, że gracz zdobył wymagane punkty
            if (Uwon != null)
            {
                Uwon.text = "Come back to the rocket ship to come back to home.";
                Uwon.gameObject.SetActive(true); // Wyświetl tekst
                StartCoroutine(HideMessageAfterDelay(4f)); // Schowaj tekst po 4 sekundach
            }
        }
    }

    private IEnumerator HideMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (Uwon != null)
        {
            Uwon.gameObject.SetActive(false); // Ukryj tekst po czasie
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Sprawdzamy, czy gracz wszedł w collider oznaczony tagiem "Home"
        if (hasWon && other.CompareTag("Home") && !reachedHome)
        {
            reachedHome = true; // Gracz dotarł do rakiety

            if (Uwon != null)
            {
                Uwon.text = "You’ve won!";
                Uwon.gameObject.SetActive(true); // Wyświetl tekst „You’ve won!”
            }

            if (NLB != null)
            {
                NLB.SetActive(true); // Pokaż przycisk przejścia do kolejnego poziomu
            }
        }
    }
}

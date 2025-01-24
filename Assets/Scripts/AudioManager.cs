using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    void Awake()
    {
        // Sprawdzamy, czy ju� istnieje instancja tego obiektu w grze
        if (instance == null)
        {
            // Je�li nie, przypisujemy go jako instancj�
            instance = this;
            DontDestroyOnLoad(gameObject);  // Nie niszcz obiektu przy �adowaniu nowej sceny
        }
        else
        {
            // Je�li instancja ju� istnieje, niszczymy ten obiekt (zapobiegamy duplikowaniu muzyki)
            Destroy(gameObject);
        }
    }
}

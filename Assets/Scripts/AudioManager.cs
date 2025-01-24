using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance;

    void Awake()
    {
        // Sprawdzamy, czy ju¿ istnieje instancja tego obiektu w grze
        if (instance == null)
        {
            // Jeœli nie, przypisujemy go jako instancjê
            instance = this;
            DontDestroyOnLoad(gameObject);  // Nie niszcz obiektu przy ³adowaniu nowej sceny
        }
        else
        {
            // Jeœli instancja ju¿ istnieje, niszczymy ten obiekt (zapobiegamy duplikowaniu muzyki)
            Destroy(gameObject);
        }
    }
}

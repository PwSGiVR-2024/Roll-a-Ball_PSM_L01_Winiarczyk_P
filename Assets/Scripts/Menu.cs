using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Referencja do panelu
    public GameObject optionsPanel;

    public void StartButton()
    {
        SceneManager.LoadScene("Level", LoadSceneMode.Single);
    }

    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }

    public void NLB_1()
    {
        SceneManager.LoadScene("Level", LoadSceneMode.Single);
    }
    public void NLB()
    {
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);
    }

    public void NLB1_1()
    {
        SceneManager.LoadScene("Level3", LoadSceneMode.Single);
    }

    public void NLB2()
    {
        SceneManager.LoadScene("Credits", LoadSceneMode.Single);
    }

    public void NLB3()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void OptionButton()
    {

        if (optionsPanel != null)
        {
            bool isActive = optionsPanel.activeSelf;
            optionsPanel.SetActive(!isActive);
        }

    }

    public void ExitOptionButton()
    {
        if (optionsPanel != null)
        {
            optionsPanel.SetActive(false); // Ukryj panel
        }

    }

    void Start()
    {
        // Mo¿esz na starcie upewniæ siê, ¿e panel jest ukryty
        if (optionsPanel != null)
        {
            optionsPanel.SetActive(false);
        }
    }

    void Update()
    {

    }
}
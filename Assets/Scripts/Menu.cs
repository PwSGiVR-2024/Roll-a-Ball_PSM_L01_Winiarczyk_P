using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("Level", LoadSceneMode.Single);

    }
    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }

    public void NLB()
    {
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);
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

    }

   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

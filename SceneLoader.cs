using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        //SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }
}

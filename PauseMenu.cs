using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject UiElements;
    public GameObject PausePanel;
    public static bool isPaused = false;

    public void SetPause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
        }

        UiElements.SetActive(!UiElements.activeSelf);
        PausePanel.SetActive(!PausePanel.activeSelf);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetPause();
        }
    }

}

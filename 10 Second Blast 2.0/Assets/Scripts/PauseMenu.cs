using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    private Controller playerInput;

    // game is pause
    public static bool GamePaused = false;

    public GameObject pauseMenuUI;
    public GameObject gameOverMenuUI;

    public GameObject firstSelection;

    private void Awake()
    {
        playerInput = new Controller();
    }

    void Start()
    {
        Debug.Log("Start Pause");
        playerInput.Gameplay.Pause.performed += _ => DeterminePause();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    // Determines if the game is in the pause menu or not, and activates or deactives it
    private void DeterminePause()
    {
        Debug.Log("Paused!");
        if (!GamePaused)
        {
            Pause();
        }
        else
        {
            Resume();
        }
    }

    // Resume hides pause menu and continues the game at normal time
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GamePaused = false;

        Debug.Log("Resuming Game...");
    }

    // Pause sets time to stop, and shows the menu for user navigation
    public void Pause()
    {
        if (!gameOverMenuUI.activeSelf)
        {
            pauseMenuUI.SetActive(true);

            Time.timeScale = 0f;
            GamePaused = true;

            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(firstSelection);

            Debug.Log("Pausing Game...");
        }
    }

    // Quit terminates the application
    public void Quit()
    {
        Debug.Log("Terminating application...");
        Application.Quit();
    }

    // Reset just goes back to the beginning of the scene
    public void Reset()
    {
        Debug.Log("Restarting current level...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Resume();
    }

}

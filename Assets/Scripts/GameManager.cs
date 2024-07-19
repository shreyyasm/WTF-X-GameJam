using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] GameObject controlsCanvas;
    public bool gameStarted = false;
    public bool gamestartWord = false;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
            Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GoToStory()
    {
        SceneManager.LoadScene(1);
    }
    public void GoToGame()
    {
        SceneManager.LoadScene(2);
    }
    public void GotoMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void OpenControlsCanvas()
    {
        controlsCanvas.SetActive(true);
        
    }
    public void CloseControlsCanvas()
    {
        controlsCanvas.SetActive(false);
        if (!gameStarted)
            keyCanvas.SetActive(true);
    }
    public GameObject OptionsCanvas;
    public GameObject keyCanvas;
    public void CloseOptionsCanvas()
    {
        OptionsCanvas.SetActive(false);
        

    }
    public void OpenOptionsCanvas()
    {
        OptionsCanvas.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public GameObject creditsScreen;
    public GameObject MainScreen;
    public void Credits()
    {
        creditsScreen.SetActive(true);
        MainScreen.SetActive(false);
    }
    public void CloseCredits()
    {
        creditsScreen.SetActive(false);
        MainScreen.SetActive(true);
    }
}

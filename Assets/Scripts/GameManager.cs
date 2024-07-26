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
        Time.timeScale = 1f;
        if (Instance == null)
            Instance = this;
    }
    public bool OptionsOpend = false;
    // Update is called once per frame
    void Update()
    {
        if(!OptionsOpend)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                if(OptionsCanvas != null){
                    OptionsCanvas.SetActive(true);}
                OptionsOpend = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
                Time.timeScale = 0;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if(OptionsCanvas != null)
                    OptionsCanvas.SetActive(false);
                OptionsOpend = false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
            }
        }
    }
    public void GoToStory()
    {
        SceneManager.LoadScene(1);
    }
    public void GoToGame()
    {
        // Scene currentscene = SceneManager.GetActiveScene();
        // SceneManager.UnloadSceneAsync(currentscene);
        SceneManager.LoadScene(2);
    }
    public void GotoMainMenu()
    {
        SceneManager.LoadScene(0,LoadSceneMode.Single);
        //int currentscene = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.UnloadSceneAsync(currentscene);
        //LeanTween.delayedCall(8f, () => { anim.SetBool("Idle", false); });
        
    }
    public void RestartGame()
    {
        // Scene currentscene = SceneManager.GetActiveScene();
        // SceneManager.UnloadSceneAsync(currentscene);
        SceneManager.LoadScene(1);
        // GoToStory();
    }
    public void OpenControlsCanvas()
    {
        controlsCanvas.SetActive(true);
        
    }
    public void CloseControlsCanvas()
    {
        controlsCanvas.SetActive(false);
        
    }
    public GameObject OptionsCanvas;
    public GameObject keyCanvas;
    public void CloseOptionsCanvas()
    {
       
        OptionsOpend = false;
        OptionsCanvas.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;

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
    public void EndScene()
    {
        SceneManager.LoadScene(3);
    }
    public void CloseCredits()
    {
        creditsScreen.SetActive(false);
        MainScreen.SetActive(true);
    }
    
}

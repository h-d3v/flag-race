using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject  optionScreen, pauseScreen, ecranDeroulementJeu;

    public string mainMenuScene;

    private bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
    }

    public void PauseUnpause()
    {
        if(!isPaused)
        {
            pauseScreen.SetActive(true);
            Time.timeScale=0;
            isPaused=true;
            //On met l'audio sur pause aussi
            AudioListener.pause = true;
            
        } else
        {
            pauseScreen.SetActive(false);
            optionScreen.SetActive(false);
            ecranDeroulementJeu.SetActive(false);
            isPaused=false;
             AudioListener.pause = false;
            Time.timeScale=1;
        }
    }

    public void OpenOptions()
    {
        optionScreen.SetActive(true);
    }

     public void CloseOptions()
    {
        optionScreen.SetActive(false);
    }

    public void OpenInfos()
    {
        ecranDeroulementJeu.SetActive(true);
    }
     public void QuitToMain()
    {
        Time.timeScale=1;
        SceneManager.LoadScene(mainMenuScene);
        
    }

    public void RecomencerPartie()
    {
        Scene scene= SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void QuitGame(){
        Application.Quit();
    }
}

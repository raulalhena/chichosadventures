using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneSwitcher : MonoBehaviour
{
    public void playGame(){
        SceneManager.LoadScene("Nivel1");
    }

    public void goMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void howToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void exit()
    {
        Application.Quit();
    } 
}

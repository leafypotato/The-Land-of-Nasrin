using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public GameObject QuitMenuUI;
    
    public void PlayerDied()
        //player is dead, activates lose screen
    {
        Debug.Log("Dead");
        QuitMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void PlayGame()
    //starts the game
    {
        SceneManager.LoadScene("World");
        Time.timeScale = 1f;
    }
    public void QuitGame()
    //ends the game when quit button pressed
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}

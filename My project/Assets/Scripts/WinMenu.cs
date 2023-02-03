using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public GameObject WinMenuUI;
    public void Win()
    //player has won, loads win screen
    {
        Debug.Log("Win");
        WinMenuUI.SetActive(true);
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

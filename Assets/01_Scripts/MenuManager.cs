using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public string MainScene = "MenuInicio";
    public string video1Scene = "VideoInicio";
    public string Juego = "Juego";
    public string Win = "Win";
    public string video2Scene = "VideoWin";
    public string GameOver = "GameOver";

    private void Start()
    {
        if (SceneManager.GetActiveScene().name != Juego)
        {
            Debug.Log("parado");
            AudioManager.instance.StopMusic();
        }
    }
    
    public void GoMainScene()
    {
        SceneManager.LoadScene(MainScene);

    }
    public void GoVideo1Scene()
    {
        SceneManager.LoadScene(video1Scene);
    }
    public void GoJuegoScene()
    {
        SceneManager.LoadScene(Juego);

    }
    public void GoWinScene()
    {
        SceneManager.LoadScene(video2Scene);
    }
    public void GoGameOverScene()
    {
        SceneManager.LoadScene(GameOver);
    }
    public void PauseGame(bool si)
    {
        if (si)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    public void ExitGame()
    {
        // Muestra un mensaje en la consola (solo visible en el editor)
        Debug.Log("El juego se cerrará.");

        // Cierra el juego
        Application.Quit();
    }
}

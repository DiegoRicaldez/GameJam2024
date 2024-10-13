using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerManager : MonoBehaviour
{
    public Image lifeImage;
    public Image cordureImage;
    public Image pointsBar;
    public GameObject PauseMenu;
    private bool paused = false;

    public int TotalPoints = 30;
    public float points = 0;

    private MenuManager menuManager;

    public AudioClip Music;

    void Start()
    {
        menuManager = FindObjectOfType<MenuManager>();
        PauseMenu.SetActive(false);

        AudioManager.instance.SetMusic(Music);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pausar();
        }
    }

    public void Pausar()
    {
        paused = !paused;
        menuManager.PauseGame();
        PauseMenu.SetActive(paused);
    }

    public void AddPoint()
    {
        points += 1;
        Debug.Log(points);
        if (points < TotalPoints)
        {
            pointsBar.fillAmount = points / TotalPoints;
        }
        else
        {
            menuManager.GoWinScene();
        }
    }

    public void ChangeCordureImage(bool si)
    {
        if (si) cordureImage.color = Color.clear;
        else cordureImage.color = Color.white;
    }

    public void ChangeLife(float life, float maxLife)
    {
        lifeImage.fillAmount = life / maxLife;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControllerManager : MonoBehaviour
{
    public Image lifeImage;
    public Image cordureImage;
    public Image pointsBar;

    public int TotalPoints = 30;
    public float points = 0;

    private MenuManager menuManager;

    void Start()
    {
        menuManager = FindObjectOfType<MenuManager>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuManager.PauseGame();
        }
    }

    public void AddPoint()
    {
        points += 1;
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

        if (life == 0)
        {
            menuManager.GoGameOverScene();
        }
    }
}

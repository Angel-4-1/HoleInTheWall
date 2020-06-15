using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Text wallPassedText;
    public Text wallFailedText;
    public GameObject gameOverWindow;
    public GameObject gameWinWindow;

    void Awake()
    {
        Instance = this;
    }

    //update texts
    public void UpdateWallPassed()
    {
        wallPassedText.text = GameStateManager.Instance.wallPassed.ToString();
    }

    public void UpdateWallFailed()
    {
        wallFailedText.text = GameStateManager.Instance.wallFailed.ToString();
    }

    //render game over window
    public void ShowGameOverWindow()
    {
        gameOverWindow.SetActive(true);
    }

    //render game win window
    public void ShowGameWinWindow()
    {
        gameWinWindow.SetActive(true);
    }
}

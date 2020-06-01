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
}

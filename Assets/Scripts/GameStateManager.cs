using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager Instance;

    [HideInInspector]
    public int wallPassed;

    [HideInInspector]
    public int wallFailed;

    public int wallFailedToGameOver;
    public int wallpassedToGameWin;
    public WallSpawner wallSpawner;

    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void passedWall()
    {
        wallPassed++;
        UIManager.Instance.UpdateWallPassed();

        if (wallPassed == wallpassedToGameWin)
        {
            GameWin();
        }
    }

    private void GameOver()
    {
        wallSpawner.canSpawn = false;
        wallSpawner.DestroyAllWalls();
        UIManager.Instance.ShowGameOverWindow();
        SoundManager.Instance.PlayGameOverSound();
    }

    private void GameWin()
    {
        wallSpawner.canSpawn = false;
        wallSpawner.DestroyAllWalls();
        UIManager.Instance.ShowGameWinWindow();
        SoundManager.Instance.PlayGameOverSound();
    }

    public void failedWall()
    {
        wallFailed++;
        UIManager.Instance.UpdateWallFailed();

        if (wallFailed == wallFailedToGameOver)
        {
            GameOver();
        }
    }
}

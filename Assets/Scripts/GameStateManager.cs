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
    }

    private void GameOver()
    {
        wallSpawner.canSpawn = false;
        wallSpawner.DestroyAllWalls();
        UIManager.Instance.ShowGameOverWindow();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject floorPrefab;
    public PlayerBehaviour playerPrefab;
    public Transform inGameParent;
    public GameObject coinPrefab;

    public PlayerBehaviour playerInstance;
    public int lastScore;

    public int gridSize = 3;

    void Awake()
    {
        App.gameManager = this;
    }

    void Start()
    {
        GoToMenu();
    }

    public void StartGame()
    {
        SpawnFloor();
        SpawnPlayer();

        App.obstacleManager.SpawnObstacles();

        App.screenManager.Show<InGameScreen>();
    }

    public void SpawnFloor()
    {
        // TODO: spawn bigger map
        for(float i= -1.1f; i <= 1.1f; i += 1.1f)
        {
            for(float j = -1.1f; j <= 1.1f; j+= 1.1f)
            {
                Instantiate(floorPrefab, new Vector3(i, 0, j), Quaternion.identity, inGameParent);
            }
        }
    }

    public void SpawnPlayer()
    {
        playerInstance = Instantiate(playerPrefab, new Vector3(0, 0.8f, 0), Quaternion.identity, inGameParent);
        playerInstance.onScoreChanged.AddListener(SpawnCoin);
        SpawnCoin();
    }

    public void DestroyInGame()
    {
        foreach(Transform child in inGameParent)
        {
            Destroy(child.gameObject);
        }
        App.obstacleManager.obstacles = new List<ObstacleBehaviour>();
    }

    public void SpawnCoin()
    {
        Vector3 pos = new Vector3(0, 0.8f, 0);
        do
        {
            pos.x = -1.1f + 1.1f * Random.Range(0, gridSize);
            pos.z = -1.1f + 1.1f * Random.Range(0, gridSize);
        } while(Vector3.Distance(pos, playerInstance.transform.position) < 0.1f);

        Instantiate(coinPrefab, pos, Quaternion.identity, inGameParent);
    }

    public void GameOver()
    {
        lastScore = playerInstance.score;
        int oldHighScore = PlayerPrefs.GetInt("highScore", 0);
        if(oldHighScore < lastScore)
        {
            PlayerPrefs.SetInt("highScore", lastScore);
        }
        App.screenManager.Hide<InGameScreen>();
        App.screenManager.Show<GameOverScreen>();
        DestroyInGame();
    }

    public void GoToMenu()
    {
        App.screenManager.Show<MenuScreen>();
        DestroyInGame();
    }
}

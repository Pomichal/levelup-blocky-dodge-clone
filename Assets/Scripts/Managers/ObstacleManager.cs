using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{

    [Header("Game Settings")]
    public float speed;

    [Header("Prefabs")]
    public ObstacleBehaviour obstaclePrefab;
    public Transform inGameParent;

    public List<ObstacleBehaviour> obstacles;

    void Awake()
    {
        App.obstacleManager = this;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartObstacle();
        }
    }

    public void SpawnObstacles()
    {
        obstacles = new List<ObstacleBehaviour>();
        for(int i=0; i < App.gameManager.gridSize; i++)
        {
            ObstacleBehaviour oX = Instantiate(obstaclePrefab, new Vector3(10, 0.8f, -1.1f + i *1.1f), Quaternion.identity, inGameParent);
            oX.Init(Vector3.right, true);
            obstacles.Add(oX);

            ObstacleBehaviour oZ = Instantiate(obstaclePrefab, new Vector3(-1.1f + i *1.1f, 0.8f, 10), Quaternion.identity, inGameParent);
            oZ.Init(Vector3.forward, false);
            obstacles.Add(oZ);
        }
    }

    public void StartObstacle()
    {
        // TODO: random selection
        obstacles[1].StartMoving();
    }
}

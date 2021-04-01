using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{

    [Header("Game Settings")]
    public float speed;
    public float speedIncrease;
    public float maxSpeed;
    public float minTime;
    public float maxTime;

    [Header("Prefabs")]
    public ObstacleBehaviour obstaclePrefab;
    public Transform inGameParent;

    public List<ObstacleBehaviour> obstacles;

    private float timer;

    void Awake()
    {
        timer = Random.Range(minTime, maxTime);
        App.obstacleManager = this;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if(timer < 0)
        {
            StartObstacle();
            timer = Random.Range(minTime, maxTime);
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
        List<ObstacleBehaviour> possibleObstacles = new List<ObstacleBehaviour>();
        foreach(ObstacleBehaviour o in obstacles)
        {
            if(!o.moving)
            {
                possibleObstacles.Add(o);
            }
        }
        if(possibleObstacles.Count == 0)
        {
            return;
        }
        possibleObstacles[Random.Range(0, possibleObstacles.Count)].StartMoving(speed);
        speed += speedIncrease;
        if(speed > maxSpeed)
        {
            speed = maxSpeed;
        }
    }
}

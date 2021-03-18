using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject floorPrefab;
    public GameObject playerPrefab;
    public Transform inGameParent;

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
        App.screenManager.Show<InGameScreen>();

        SpawnFloor();
        SpawnPlayer();
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
        Instantiate(playerPrefab, new Vector3(0, 0.8f, 0), Quaternion.identity, inGameParent);
    }

    public void DestroyFloor()
    {
        foreach(Transform child in inGameParent)
        {
            Destroy(child.gameObject);
        }
    }

    public void GoToMenu()
    {
        App.screenManager.Show<MenuScreen>();
        DestroyFloor();
    }
}

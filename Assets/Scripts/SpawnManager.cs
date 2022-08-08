using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] Obstacles = new GameObject[5];
    int randomObject;
    Vector3 posi = new Vector3();
    float randomPosiX;
    float startRange = 25.0f, endRange = 35.0f;

    float startTime = 0.0f;
    float repeatTime = 2.2f;

    void Start()
    {
        InvokeRepeating("GetRandomObstacle", startTime, repeatTime);
    }

    void GetRandomObstacle()
    {
        if (PlayerController.gameOver == false)
        {
            randomObject = Random.Range(0, Obstacles.Length);
            randomPosiX = Random.Range(startRange, endRange);
            posi.Set(randomPosiX, 0, 0);
            Instantiate(Obstacles[randomObject], posi, Obstacles[randomObject].transform.rotation);
        }

    }
}

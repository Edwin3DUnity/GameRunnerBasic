using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    private Vector3 spawnPos;
    public GameObject[] obstacles;
    private int indexObstacles;

    private float starDalay = 1;

    [SerializeField, Range(1, 5), Tooltip("Tiempo de espera del proximo obstáculo ")]
    private float timeRate = 3;
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = transform.position;
        
        InvokeRepeating("GenerarObstacles", starDalay, timeRate);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void GenerarObstacles()
    {
        indexObstacles = Random.Range(0, obstacles.Length);


        Instantiate(obstacles[indexObstacles], spawnPos, obstacles[indexObstacles].transform.rotation);

    }
}

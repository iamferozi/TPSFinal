using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour {

    public GameObject[] enemy;

    [Header("Axis Minimum")]
    public float xMin;
    public float yMin;
    public float zMin;

    [Header("Axis Maximum")]
    public float xMax;
    public float yMax;
    public float zMax;

    public int numberofSpawns;
    public float spawnDelay;
    //public float xRan;
    //public float yRan;
    //public float zRan;

    public int timeBetweenNextWave;
    public Text timer;
    public bool takingAway = false;
    public bool stopSpawning;

    // Use this for initialization
    void Start () 
    {
        timer.text = timeBetweenNextWave.ToString();
        InvokeRepeating("SpawnRandomenemy", timeBetweenNextWave, timeBetweenNextWave);
        //InvokeRepeating("Timer",1, timeBetweenNextWave);
        //SpawnRandomenemy();
	}

    private void Update()
    {
        Timer();
    }

    public void Timer()
    {
        if (takingAway == false && timeBetweenNextWave > 0)
        {
            StartCoroutine(SpawnerTimer());
        }
    }

    public void SpawnRandomenemy()
    {
        //xRan = Random.Range(xMin, xMax);
        //yRan = Random.Range(yMin, yMax);
        //zRan = Random.Range(zMin, zMax);

        //commented
        for (int j = 0; j < numberofSpawns; j++)
        {
            for (int i = 0; i < enemy.Length; i++)
            {
                //Debug.LogError("barrels");
                Instantiate(enemy[i], new Vector3(
                Random.Range(xMin, xMax),
                Random.Range(yMin, yMax),
                Random.Range(zMin, zMax)),
                Quaternion.identity);
            }
        }


        //StartCoroutine(EnemySpawnDelay());
        if (stopSpawning == true)
        {
            CancelInvoke("SpawnRandomenemy");
        }
    }

    IEnumerator EnemySpawnDelay()
    {
        for (int j = 0; j < numberofSpawns; j++)
        {
            //for (int i = 0; i < enemy.Length; i++)
            //{
                //Debug.LogError("barrels");
                Instantiate(enemy[Random.Range(0,1)], new Vector3(
                Random.Range(xMin, xMax),
                Random.Range(yMin, yMax),
                Random.Range(zMin, zMax)),
                Quaternion.identity);
                yield return new WaitForSecondsRealtime(spawnDelay);
            //}
        }
    }

    IEnumerator SpawnerTimer()
    {
        takingAway = true;
        yield return new WaitForSecondsRealtime(1);
        timeBetweenNextWave -= 1;
        //if (timeBetweenNextWave < 10)
        //{
        //    timer.text = "00:0" + timeBetweenNextWave;
        //}
        //else
        //{
        //    timer.text =  "00:" + timeBetweenNextWave;
        //}
        timer.text = timeBetweenNextWave.ToString();
        takingAway = false;
    }
}

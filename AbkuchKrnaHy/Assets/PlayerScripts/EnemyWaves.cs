using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyWaves : MonoBehaviour
{
    public Wave[] waves;
    public GameObject enemy; // 
    Wave currentWave;
    int currentWaveNumber;
    int enemiesRemainingToSpawn;
    int enemiesRemainingAlive;
    float nextSpawnTime;
    public Transform[] spawnPoints;
    public int timeBetweenNextWave;
    public Text timer;
    public bool takingAway = false;

    void Start()
    {
        NextWave();
    }

    void Update()
    {
        //timeBetweenNextWave -= timeBetweenNextWave * Time.deltaTime;
        //timer.text = timeBetweenNextWave.ToString();

        if (takingAway == false && timeBetweenNextWave > 0)
        {
            StartCoroutine(TimerTake());
            //NextWave();
            SpawnerEnemy();
        }

        //print(" wave nuumber : " + currentWaveNumber + " enemy remining to respawn : " 
        //    + enemiesRemainingToSpawn + " enemt remining a live : " + enemiesRemainingAlive);

    } // end update

    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
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

    public void SpawnerEnemy()
    {
        if (enemiesRemainingToSpawn > 0 && Time.time > nextSpawnTime)
        {
            enemiesRemainingToSpawn--;
            nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Instantiate(enemy, spawnPoints[spawnPointIndex].position,
                spawnPoints[spawnPointIndex].rotation);
        }
    }

    void NextWave()
    {
        currentWaveNumber++;
        print("Wave: " + currentWaveNumber);
        if (currentWaveNumber - 1 < waves.Length)
        {
            currentWave = waves[currentWaveNumber - 1];
            enemiesRemainingToSpawn = currentWave.enemyCount;
            enemiesRemainingAlive = enemiesRemainingToSpawn;
        }

    }

    [System.Serializable]
    public class Wave
    {
        public int enemyCount;
        public float timeBetweenSpawns;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour {

    public GameObject[] Objects;

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

    // Use this for initialization
    void Start () {
        SpawnRandomObjects();
	}

    public void SpawnRandomObjects()
    {
        //xRan = Random.Range(xMin, xMax);
        //yRan = Random.Range(yMin, yMax);
        //zRan = Random.Range(zMin, zMax);

        //commented
        for (int j = 0; j < numberofSpawns; j++)
        {
            for (int i = 0; i < Objects.Length; i++)
            {
                //Debug.LogError("barrels");
                Instantiate(Objects[i], new Vector3(
                Random.Range(xMin, xMax),
                Random.Range(yMin, yMax),
                Random.Range(zMin, zMax)),
                Quaternion.identity);
            }
        }

        //StartCoroutine(EnemySpawnDelay());
    }

    IEnumerator EnemySpawnDelay()
    {
        for (int j = 0; j < numberofSpawns; j++)
        {
            //for (int i = 0; i < Objects.Length; i++)
            //{
                //Debug.LogError("barrels");
                Instantiate(Objects[Random.Range(0,2)], new Vector3(
                Random.Range(xMin, xMax),
                Random.Range(yMin, yMax),
                Random.Range(zMin, zMax)),
                Quaternion.identity);
                yield return new WaitForSecondsRealtime(spawnDelay);
            //}
        }
    }
}

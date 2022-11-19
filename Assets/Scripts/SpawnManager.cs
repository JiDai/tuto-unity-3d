using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int spawnRangeX = 10;
    public int spawnPosZ = 20;
    public int animalIndex;
    public GameObject[] animalPrefabs;

    private float startDelay = 2f;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        InvokeRepeating(nameof(SpawnRandomAnimal), startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SpawnRandomAnimal();
        }
    }

    void SpawnRandomAnimal()
    {
        int randomIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spawn = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
        Instantiate(animalPrefabs[randomIndex], spawn, animalPrefabs[randomIndex].transform.rotation);
    }

}

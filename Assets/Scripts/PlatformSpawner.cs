using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public Transform player;

    public List<Transform> spawnPoints = new List<Transform>();

    private List<bool> occupied;

    void Start()
    {
        occupied = new List<bool>(new bool[spawnPoints.Count]);
        SpawnInitialPlatforms(3);
    }

    void Update()
    {
        if (CountOccupied() < 5)
        {
            SpawnAtRandomFreePoint();
        }
    }

    void SpawnInitialPlatforms(int count)
    {
        for (int i = 0; i < count; i++)
        {
            SpawnAtRandomFreePoint();
        }
    }

    void SpawnAtRandomFreePoint()
    {
        List<int> freeIndices = new List<int>();
        for (int i = 0; i < occupied.Count; i++)
        {
            if (!occupied[i]) freeIndices.Add(i);
        }

        if (freeIndices.Count == 0) return;

        int randIndex = freeIndices[Random.Range(0, freeIndices.Count)];
        Transform spawnPoint = spawnPoints[randIndex];

        GameObject platform = Instantiate(platformPrefab, spawnPoint.position, Quaternion.identity, transform);
        PlatformTracker tracker = platform.AddComponent<PlatformTracker>();
        tracker.spawner = this;
        tracker.spawnPointIndex = randIndex;

        occupied[randIndex] = true;
    }

    public void FreeSpawnPoint(int index)
    {
        if (index >= 0 && index < occupied.Count)
        {
            occupied[index] = false;
        }
    }

    int CountOccupied()
    {
        int count = 0;
        foreach (bool b in occupied)
            if (b) count++;
        return count;
    }
}

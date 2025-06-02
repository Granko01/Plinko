using System.Collections.Generic;
using UnityEngine;

public class PlatformTracker : MonoBehaviour
{
    public PlatformSpawner spawner;
    public int spawnPointIndex;


    private void Start()
    {
        spawner = FindObjectOfType<PlatformSpawner>();
    }

    void Update()
    {
        if (transform.position.y > spawner.player.position.y + 1000f)
        {
            spawner.FreeSpawnPoint(spawnPointIndex);
            Destroy(gameObject);
        }
    }
}

using System.Collections.Generic;
using UnityEngine;

public class PlatformContainerMover : MonoBehaviour
{
    public float acceleration = 0.1f;
    public float scrollSpeed = 2f;
    private float initialY;
    //public List<Transform> spawnPoints = new List<Transform>();
    //public GameObject platformPrefab;

    void Start()
    {
        initialY = transform.position.y;
    }

    void Update()
    {
        scrollSpeed += acceleration * Time.deltaTime;
        transform.position += Vector3.down * scrollSpeed * Time.deltaTime;
       // SpawnOtherPlatorms();
    }

    //public void SpawnOtherPlatorms()
    //{
    //    if (transform.position.y <= initialY - 300f)
    //    {
    //        Debug.Log("Moved down 100 units, spawn platforms!");
    //        initialY = transform.position.y;
    //        int randIndex = Random.Range(0, spawnPoints.Count);
    //        Transform spawnPoint = spawnPoints[randIndex];

    //        GameObject platform = Instantiate(platformPrefab, spawnPoint.position, Quaternion.identity, transform);
    //    }
    //}
}

using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private float highestY;

    void Start()
    {
        if (player != null)
            highestY = player.position.y;
    }

    void LateUpdate()
    {
        if (player == null) return;

        if (player.position.y > highestY)
        {
            highestY = player.position.y;

            Vector3 newPos = new Vector3(transform.position.x, highestY, transform.position.z);
            transform.position = newPos;
        }
    }
}


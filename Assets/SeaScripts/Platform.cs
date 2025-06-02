using UnityEngine;

public class Platform : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float moveRange = 3f;

    private Vector3 startPos;
    private int direction;
    private float offset;

    void Start()
    {
        startPos = transform.position;

        direction = Random.value < 0.5f ? -1 : 1;

        offset = Random.Range(0f, 1f);
    }

    void Update()
    {
        float moveAmount = Mathf.Sin((Time.time + offset) * moveSpeed) * moveRange;
        transform.position = new Vector3(startPos.x + moveAmount * direction, transform.position.y, transform.position.z);
    }
}

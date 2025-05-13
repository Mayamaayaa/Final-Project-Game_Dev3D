using UnityEngine;

public class MovingCloud : MonoBehaviour
{
    public Vector3 direction = Vector3.right;
    public float distance = 2f;
    public float speed = 1f;

    private Vector3 startPos;
    private bool forward = true;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        Vector3 move = direction.normalized * speed * Time.deltaTime;
        transform.Translate(forward ? move : -move);

        if (Vector3.Distance(startPos, transform.position) >= distance)
            forward = !forward;
    }
}

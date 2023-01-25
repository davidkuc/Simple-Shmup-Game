using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 0.1f;
    bool isMoving;

    private void Update()
    {
        if (isMoving)
        {
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
        }
    }

    [ContextMenu("Start Moving")]
    public void StartMoving()
    {
        isMoving = true;
    }

    [ContextMenu("Stop Moving")]
    public void StopMoving()
    {
        isMoving = false;
    }
}

using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveDistanceLimit;
    [SerializeField] float stepDistance = 1;
    Vector2 startingPoint;

    private void Awake()
    {
        startingPoint = transform.position;
    }

    public void MoveUp()
    {
        if (!ExceededDistanceLimit())
            return;

        transform.position += new Vector3(0, stepDistance, 0);
    }

    public void MoveDown()
    {
        if (!ExceededDistanceLimit())
            return;

        transform.position -= new Vector3(0, stepDistance, 0);
    }

    private bool ExceededDistanceLimit()
    {
        return Vector2.Distance(startingPoint, transform.position) > moveDistanceLimit;
    }
}

using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    int currentIndex = 2;
    [SerializeField] float stepDistance = 0.1f;

    public void MoveUp()
    {
        if (ReachedLimitRow(up: true))
            return;

        transform.position += new Vector3(0, stepDistance, 0);
        currentIndex++;
    }

    public void MoveDown()
    {
        if (ReachedLimitRow(up: false))
            return;

        transform.position += new Vector3(0, -stepDistance, 0);
        currentIndex--;
    }

    private bool ReachedLimitRow(bool up)
    {
        return up ? currentIndex + 1 > GameConstants.maxRowIndex : currentIndex - 1 < 0;
    }

    public void ResetStats()
    {
        currentIndex = 2;
    }
}

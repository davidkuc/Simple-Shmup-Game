using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] int maxRowIndex = 4;
    int currentIndex = 2;
    [SerializeField] float stepDistance = 0.1f;

    public void MoveUp()
    {
        if (ReachedLimitRow(up: true))
            return;

        transform.position += new Vector3(0, stepDistance, 0);
        currentIndex++;
        Debug.Log("Player Move up!");
    }

    public void MoveDown()
    {
        if (ReachedLimitRow(up: false))
            return;

        transform.position += new Vector3(0, -stepDistance, 0);
        currentIndex--;
        Debug.Log("Player Move Down!");
    }

    private bool ReachedLimitRow(bool up)
    {
        return up ? currentIndex + 1 > maxRowIndex : currentIndex - 1 < 0;
    }
}

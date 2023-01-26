using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Scriptable Objects/Player Data")]
public class PlayerData_SO : ScriptableObject
{
    public int MaxHP;

    public int BestScore;
    public int LatestScore;
    public int CurrentScore;
}

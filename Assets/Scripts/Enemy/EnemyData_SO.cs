using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/Enemy Data")]
public class EnemyData_SO : ScriptableObject
{
    public int MaxHP;
    public int DMG;
    public int PointsForDeath;
}

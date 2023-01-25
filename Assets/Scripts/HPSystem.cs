public class HPSystem
{
    private int maxHP;

    private int currentHP;

    public bool IsDead => CurrentHP <= 0;

    public int CurrentHP => currentHP;

    public void SetMaxHP(int maxHP)
    {
        this.maxHP = maxHP;
        currentHP = maxHP;
    }

    public void TakeDamage(int damagePerHit) => currentHP -= damagePerHit;

    public void ResetHP() => currentHP = maxHP;
}

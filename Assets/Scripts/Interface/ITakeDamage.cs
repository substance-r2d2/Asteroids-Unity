public interface ITakeDamage
{
    int MaxHealth { get; }

    int CurrHealth { get; set; }

    void TakeDamage(int Damage);

    System.Action<int> ModifyHealth { get; set; }
}

public interface IDoDamage
{
    int DamageToApply { get; }

    void ApplyDamage(int Damage, ITakeDamage ApplyTo);

    System.Action<ITakeDamage> DamageApplied { get; set; }
}

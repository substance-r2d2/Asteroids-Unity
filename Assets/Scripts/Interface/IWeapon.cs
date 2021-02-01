internal interface IWeapon
{
    void FireWeapon(UnityEngine.Transform InstigatorTransform);

    bool CanFire();
}

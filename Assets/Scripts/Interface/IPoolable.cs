public interface IPoolable
{
    UnityEngine.GameObject PooledGObj { get; }

    string PoolId { get; }

    void Pool();
}

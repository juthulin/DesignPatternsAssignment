using UnityEngine;

public abstract class ObjectPoolItem<T>
{
    public GameObject ObjectToPool  = default;
    public T          ObjectType    = default;
    public int        AmountToPool  = default;
    public bool       PoolCanExpand = default;
}
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour
{
    /// <summary>
    /// ObjectPoolPattern: This objectpool base can be used to create different kinds of object pools
    /// that are needed for the project.
    /// </summary>
    protected Dictionary<T, List<GameObject>> MappedPools = new Dictionary<T, List<GameObject>>();
    [SerializeField] protected List<List<GameObject>> ListOfPools = new List<List<GameObject>>();

    protected abstract void Awake();

    protected abstract void Start();

    public abstract GameObject GetPooledObject(in T objectType);
}
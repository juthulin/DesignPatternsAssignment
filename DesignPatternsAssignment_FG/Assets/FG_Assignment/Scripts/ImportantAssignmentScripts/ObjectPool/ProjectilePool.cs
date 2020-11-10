using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-40)]
public class ProjectilePool : ObjectPool<ProjectileType>
{
    /// <summary>
    /// ObjectPoolPattern: This projectile pool could have its own factory that could create the objects
    /// that it wants to pool.
    /// </summary>
    [SerializeField] private List<ProjectilePoolItem> _projectilesToPool;
    
    public static ProjectilePool Instance { get; private set; }
    
    protected override void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    protected override void Start()
    {
        foreach (ProjectilePoolItem item in _projectilesToPool)
        {
            List<GameObject> pool = new List<GameObject>();
            ListOfPools.Add(pool);
            MappedPools.Add(item.ObjectType, pool);

            for (int i = 0; i < item.AmountToPool; i++)
            {
                GameObject obj = Instantiate(item.ObjectToPool, transform);
                obj.SetActive(false);
                pool.Add(obj);
            }
        }
    }

    public override GameObject GetPooledObject(in ProjectileType objectType)
    {
        if (!MappedPools.ContainsKey(objectType)) return null;

        for (int i = 0; i < MappedPools[objectType].Count; i++)
        {
            if (!MappedPools[objectType][i].activeInHierarchy)
                return MappedPools[objectType][i];
        }

        foreach (ProjectilePoolItem item in _projectilesToPool)
        {
            if (item.ObjectType == objectType && item.PoolCanExpand)
            {
                GameObject obj = Instantiate(item.ObjectToPool, transform);
                obj.SetActive(false);
                MappedPools[objectType].Add(obj);
                return obj;
            }
        }
        return null;
    }
}

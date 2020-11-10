using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class AttackProvider
{
    private static Dictionary<AttackIdentifier, AttackSchema> _attackSchemata;

    static AttackProvider()
    {
        Debug.Log("AttackProvider constructor here! Can you hear me?");
        Initialize();
    }

    private static void Initialize()
    {
        var loadedAttackSchemata = Resources.LoadAll<AttackSchema>("AttackSchemas");

        if (loadedAttackSchemata == null || loadedAttackSchemata.Length == 0)
            throw new Exception("Failed to load attackSchemata...");

        _attackSchemata = loadedAttackSchemata?.ToDictionary(a => a.AttackIdentifier, a => a);

        Debug.Log("AttackSchemata successfully loaded");
    }

    public static AttackSchema GeAttackSchema(AttackIdentifier id)
    {
        if (!_attackSchemata.ContainsKey(id))
            throw new Exception($"no attackSchema found with: {id}");

        return _attackSchemata[id];
    }
}
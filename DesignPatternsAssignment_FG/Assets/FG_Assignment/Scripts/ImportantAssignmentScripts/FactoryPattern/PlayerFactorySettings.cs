using UnityEngine;

[CreateAssetMenu(menuName = "PlayerFactorySettings")]
public class PlayerFactorySettings : ScriptableObject
{
    public GameObject playerPrefab;
    public Transform  spawnTransform;
}

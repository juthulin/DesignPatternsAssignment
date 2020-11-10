using UnityEngine;

[CreateAssetMenu(menuName = "AttackSchema")]
public class AttackSchema : ScriptableObject
{
    public AttackIdentifier AttackIdentifier;
    public int              damageAmount;
    public float            attackSpeed;
}

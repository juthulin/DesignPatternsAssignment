using UnityEngine;

[CreateAssetMenu(menuName = "Actor Settings")]
public class ActorSettings : ScriptableObject
{
    public int       maxHealth;
    public float     movementAcceleration;
    public float     jumpForce;
}

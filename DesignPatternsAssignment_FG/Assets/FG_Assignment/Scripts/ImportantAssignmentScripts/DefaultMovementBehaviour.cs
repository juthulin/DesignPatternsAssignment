using UnityEngine;

public class DefaultMovementBehaviour : MovementBehaviourBase
{
    private readonly Rigidbody     _rb;
    private readonly ActorSettings _settings;

    public DefaultMovementBehaviour(in Component component, in ActorSettings actorSettings)
    {
        _rb = component.GetComponent<Rigidbody>();
        _settings = actorSettings;
    }

    public override void MoveRight()
    {
        _rb.AddForce(Vector3.right * (_settings.movementAcceleration * Time.fixedDeltaTime),
            ForceMode.VelocityChange);
    }

    public override void MoveLeft()
    {
        _rb.AddForce(Vector3.left * (_settings.movementAcceleration * Time.fixedDeltaTime),
            ForceMode.VelocityChange);
    }

    public override void Jump()
    {
        _rb.AddForce(Vector3.up * (_settings.jumpForce), ForceMode.VelocityChange);
    }
}
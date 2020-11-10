using System;
using UnityEngine;

public class PlayerController : MonoBehaviour, Idamageable
{
    /// <summary>
    /// DecoratorPattern: The playerController uses a form of decorator pattern to expand the
    /// playerController with the behaviours it needs for play.
    /// StrategyPattern: The movement and shooting behaviours derive from a base class and could
    /// easily be swapped out for other types of movement and shooting behaviours.
    /// </summary>
    private MovementBehaviourBase _defaultMovementBehaviour;
    private ShootingBehaviourBase _defaultShootingBehaviour;
    private HealthSystem      _healthSystem;
    
    private bool         _jump      = false;
    private AttackSchema _currentAttackSchema;

    [SerializeField] private ActorSettings playerSettings;
    [SerializeField] private Transform     gunBarrel;
    [SerializeField] private Transform     firePoint;

    public bool MoveLeft { get; set; } = false;
    public bool MoveRight { get; set; } = false;
    public Guid ObjectID { get; set; }

    public void Initialize()
    {
        _defaultShootingBehaviour = new DefaultShootingBehaviour(gunBarrel, firePoint);
        _defaultMovementBehaviour = new DefaultMovementBehaviour(this, playerSettings);
        _healthSystem = new HealthSystem(playerSettings);
        _healthSystem.Subscribe(UIManager.Instance); // subscribes the ui managers health bar to the players health system.
    }

    public void Jump()
    {
        _jump = true;
    }

    public void Attack()
    {
        _defaultShootingBehaviour?.Shoot();
    }


    public void Tick()
    {
        _defaultShootingBehaviour?.Tick();
    }

    private void FixedUpdate()
    {
        if (MoveLeft) _defaultMovementBehaviour?.MoveLeft();
        if (MoveRight) _defaultMovementBehaviour?.MoveRight();
        if (_jump)
        {
            _defaultMovementBehaviour?.Jump();
            _jump = false;
        }
    }

    public void TakeDamage(ValueType amount)
    {
        _healthSystem.DealDamage((int) amount);
    }
}
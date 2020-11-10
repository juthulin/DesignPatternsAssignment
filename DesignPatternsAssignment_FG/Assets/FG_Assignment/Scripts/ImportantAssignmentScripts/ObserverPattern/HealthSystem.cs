using System.Collections.Generic;

public class HealthSystem : ISubject
{
    /// <summary>
    /// ObserverPattern: The health system send a notification to its subscribers when the health value
    /// has changed. Each health system can have its own set of subscribers.
    /// </summary>
    private List<ISubscriber> _subscribers = new List<ISubscriber>();
    private int _currentHealth = default;

    public int MaxHealth { get; private set; } = default;
    public int CurrentHealth
    {
        get => _currentHealth;
        private set
        {
            if (value > MaxHealth)
            {
                // Player gets max health.
                _currentHealth = MaxHealth;
                Notify();
            }
            else if (value < 0)
            {
                // player will die.
                _currentHealth = 0;
                Notify();
                GameManager.Instance.GameOver(); //todo gameManager in charge of this
            }
            else
            {
                // Player takes damage.
                _currentHealth = value;
                Notify();
            }
        }
    }

    public HealthSystem(in ActorSettings settings)
    {
        MaxHealth = settings.maxHealth;
        CurrentHealth = MaxHealth;
    }

    public void DealDamage(int amount)
    {
        CurrentHealth -= amount;
    }

    public void Heal(int amount)
    {
        CurrentHealth += amount;
    }
    
    public void Subscribe(ISubscriber subscriber)
    {
        if (_subscribers.Contains(subscriber)) return;
        _subscribers.Add(subscriber);
    }

    public void Unsubscribe(ISubscriber subscriber)
    {
        if (!_subscribers.Contains(subscriber)) return;
        _subscribers.Remove(subscriber);
    }

    public void Notify()
    {
        foreach (ISubscriber subscriber in _subscribers)
        {
            subscriber.SubscriberUpdate(this);
        }
    }
}

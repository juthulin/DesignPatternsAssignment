using System.Collections.Generic;

public enum GameState
{
    StartState,
    PlayState,
    PauseState
}

public class GameStateManager : ISubject
{
    /// <summary>
    /// ObserverPattern: The game state manager is a subject in the observer pattern and can
    /// send notifications to its subscribers when something has changed.
    /// </summary>
    private List<ISubscriber> _subscribers = new List<ISubscriber>();

    public bool ShouldPause { get; private set; } = false;

    public GameState GameState { get; private set; }

    public void ChangeGameState(GameState gameState)
    {
        GameState = gameState;
        Notify();
    }

    public void Subscribe(ISubscriber subscriber)
    {
        this._subscribers.Add(subscriber);
    }

    public void Unsubscribe(ISubscriber subscriber)
    {
        this._subscribers.Remove(subscriber);
    }

    public void Notify()
    {
        foreach (ISubscriber subscriber in _subscribers)
        {
            subscriber.SubscriberUpdate(this);
        }
    }
}
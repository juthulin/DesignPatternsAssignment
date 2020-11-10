public interface ISubject
{
    /// <summary>
    /// Attaches an observer to the subject,
    /// which lets the subject notify the subscribers when something has changed.
    /// </summary>
    /// <param name="subscriber"></param>
    void Subscribe(ISubscriber subscriber);

    /// <summary>
    /// Detaches an observer from the subject so it will no longer get notified.
    /// </summary>
    /// <param name="subscriber"></param>
    void Unsubscribe(ISubscriber subscriber);

    /// <summary>
    /// Notifies all the observers about an event.
    /// </summary>
    void Notify();
}

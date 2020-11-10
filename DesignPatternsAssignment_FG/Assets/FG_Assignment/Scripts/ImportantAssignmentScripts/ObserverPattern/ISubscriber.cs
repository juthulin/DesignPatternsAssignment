public interface ISubscriber
{
    /// <summary>
    /// Lets the subscriber receive an update about the status of the subject,
    /// that the subscriber can act upon.
    /// </summary>
    /// <param name="subject"></param>
    void SubscriberUpdate(ISubject subject);
}

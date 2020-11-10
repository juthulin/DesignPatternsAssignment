using UnityEngine;

public abstract class UIElement : MonoBehaviour, ISubscriber
{
    public abstract void SubscriberUpdate(ISubject subject);
}
using UnityEngine.UI;

public class UI_Bar : UIElement
{
    private Image _bar;

    private void Awake()
    {
        _bar = GetComponent<Image>();
    }

    public override void SubscriberUpdate(ISubject subject)
    {
        
    }
}
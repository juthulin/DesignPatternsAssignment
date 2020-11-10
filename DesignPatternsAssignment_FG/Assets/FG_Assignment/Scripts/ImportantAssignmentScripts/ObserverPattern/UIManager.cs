using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour, ISubscriber
{
    [SerializeField] private Image healthBar;

    public static UIManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void UpdateHealthBar(float currentAmount, float maxAmount)
    {
        healthBar.fillAmount = currentAmount == 0f ? 0f : currentAmount / maxAmount;
    }
    
    public void SubscriberUpdate(ISubject subject)
    {
        if (subject is HealthSystem healthSystem) UpdateHealthBar(healthSystem.CurrentHealth, healthSystem.MaxHealth);
    }
}
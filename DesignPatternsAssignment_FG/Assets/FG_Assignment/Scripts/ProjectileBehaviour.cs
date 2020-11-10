using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    private Transform _cachedTransform = default;

    [SerializeField] private Rigidbody rb           = default;
    [SerializeField] private float     speed        = default;
    [SerializeField] private int       damageAmount = default;

    private void Awake()
    {
        _cachedTransform = transform;
    }

    private void OnEnable()
    {
        rb.velocity = _cachedTransform.forward * speed;
    }

    private void OnCollisionEnter(Collision other)
    {
        var obj = other.gameObject.GetComponent<Idamageable>();
        if (obj != null)
        {
            HandleDamage(obj);
        }

        DisableProjectile();
    }

    private void HandleDamage(Idamageable obj)
    {
        GameManager.Instance.Commander.Execute<CommandDealDamage>(new object[] {obj, damageAmount});
    }

    private void DisableProjectile() => gameObject.SetActive(false);

    private void OnDisable()
    {
        rb.velocity = Vector3.zero;
    }
}
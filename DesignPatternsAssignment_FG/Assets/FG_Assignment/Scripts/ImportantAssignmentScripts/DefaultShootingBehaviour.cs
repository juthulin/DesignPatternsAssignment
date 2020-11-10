using UnityEngine;

public class DefaultShootingBehaviour : ShootingBehaviourBase
{
    private Transform _gunBarrel;
    private Transform _firePoint;
    private Camera    _cam;

    public DefaultShootingBehaviour(Transform gunBarrel, Transform firePoint)
    {
        _gunBarrel = gunBarrel;
        _firePoint = firePoint;
        _cam = Camera.main;
    }

    public override void Tick()
    {
        Vector3 gunPos    = _gunBarrel.position;
        Vector3 mousePos  = Input.mousePosition;
        Vector3 objectPos = _cam.WorldToScreenPoint(gunPos);
        
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y;
        mousePos.z = gunPos.z;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        _gunBarrel.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    public override void Shoot()
    {
        GameObject obj = ProjectilePool.Instance.GetPooledObject(ProjectileType.PlayerProjectile);
        obj.transform.SetPositionAndRotation(_firePoint.position, _firePoint.rotation);
        obj.SetActive(true);
    }
}

using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public float speed;

    [Header("Tiro")]
    public Transform[] firePoints; // múltiplos canos (como em Gradius)
    public float fireRate = 0.25f;
    private float fireCooldown = 0f;

    void Update()
    {
        fireCooldown -= Time.deltaTime;

        if (Input.GetButton("Fire1") && fireCooldown <= 0f)
        {
            Shoot();
            fireCooldown = fireRate;
        }
    }

    void Shoot()
    {
        foreach (var point in firePoints)
        {

            BulletPool.Instance.GetBullet(point.position, point.rotation);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}

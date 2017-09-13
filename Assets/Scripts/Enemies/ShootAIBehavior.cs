using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAIBehavior : MonoBehaviour {

    public Bullet projectile;
    public float timeBetweenShots;
    public float distanceToShootPlayer;

    [SerializeField]
    private DataTypes.World myWorld;
    private float currentShotCooldown;
    private Vector3 dirToPlayer;

    void Start()
    {
        currentShotCooldown = 0.0f;
    }

    void Update()
    {
        if (currentShotCooldown > 0.0f)
            currentShotCooldown -= Time.deltaTime;

        dirToPlayer = transform.position - WorldManager.instance.GetPlayerLocation(myWorld);
        Debug.Log("Enemy location: " + transform.position);
        if (dirToPlayer.magnitude <= distanceToShootPlayer && currentShotCooldown <= 0.0f)
            ShootProjectile();
    }

    private void ShootProjectile()
    {
        var directiontToShoot = dirToPlayer.x >= 0.0 ? Vector3.left : Vector3.right;

        Debug.Log("Shooting bullet");
        Bullet newBullet = Instantiate<Bullet>(projectile, transform.position, Quaternion.identity);
        newBullet.Init(directiontToShoot, DataTypes.BulletOwner.Enemy);
        currentShotCooldown = timeBetweenShots;
    }
}

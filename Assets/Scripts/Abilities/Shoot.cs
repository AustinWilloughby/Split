using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public Bullet projectile;
    public float timeBetweenShots;
    private float currentShotCooldown;

    private PlayerMovement myPlayerInfo;

    void Start()
    {
        myPlayerInfo = gameObject.GetComponent<PlayerMovement>();
        currentShotCooldown = 0.0f;
    }

    private void Update()
    {
        if (currentShotCooldown > 0.0f)
        {
            currentShotCooldown -= Time.deltaTime;
        }

        // A on XBox controller
        if (Input.GetButtonDown("Fire1") && myPlayerInfo.active && currentShotCooldown <= 0.0f)
        {
            ShootProjectile();
        }
    }

    private void ShootProjectile()
    {
        Bullet newBullet = Instantiate<Bullet>(projectile, transform.position, Quaternion.identity);
        newBullet.Init(myPlayerInfo.directionFacing);
        currentShotCooldown = timeBetweenShots;
    }
}

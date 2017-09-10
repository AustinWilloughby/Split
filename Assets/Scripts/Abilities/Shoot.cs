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

        if (Input.GetButtonDown("Fire4") && myPlayerInfo.active && currentShotCooldown <= 0.0f)
        {
            ShootProjectile(DataTypes.worldDiffY);
        }

        // A on XBox controller
        if (Input.GetButtonDown("Fire5") && myPlayerInfo.active && currentShotCooldown <= 0.0f)
        {
            ShootProjectile(0.0f);
        }
    }

    private void ShootProjectile(float yOffset)
    {
        float newYOffset = 0.0f;
        if (myPlayerInfo.currentWorld == DataTypes.World.WorldOne)
        {
            newYOffset = yOffset;
        }
        else
        {
            newYOffset = yOffset;
        }
        Bullet newBullet = Instantiate<Bullet>(projectile, new Vector3(transform.position.x, transform.position.y + newYOffset, transform.position.z), Quaternion.identity);
        newBullet.Init(myPlayerInfo.directionFacing, DataTypes.BulletOwner.Player);
        currentShotCooldown = timeBetweenShots;
    }
}

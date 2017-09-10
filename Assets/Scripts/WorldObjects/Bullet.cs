using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float bulletSpeed;
    public float timeToDestroyBullet;
    public int damage;

    [HideInInspector]
    public DataTypes.BulletOwner myOwner;

    private Rigidbody2D myRigidBody;
	// Use this for initialization
	void Awake () {
        myRigidBody = gameObject.GetComponent<Rigidbody2D>();
	}

    public void Init(Vector3 direction, DataTypes.BulletOwner owner)
    {
        Debug.Log("Initalizing bullet" + timeToDestroyBullet);
        myOwner = owner;

        direction.Normalize();
        myRigidBody.velocity = bulletSpeed * direction;

        Destroy(gameObject, timeToDestroyBullet);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Destroying bullet" + timeToDestroyBullet);

        Destroy(gameObject);
    }
}

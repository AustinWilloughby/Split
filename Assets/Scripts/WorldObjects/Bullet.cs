using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float bulletSpeed;

    Rigidbody2D myRigidBody;
	// Use this for initialization
	void Awake () {
        myRigidBody = gameObject.GetComponent<Rigidbody2D>();
	}

    public void Init(Vector3 direction)
    {
        direction.Normalize();

        myRigidBody.velocity = bulletSpeed * direction;

        Destroy(gameObject, 2.0f);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
}

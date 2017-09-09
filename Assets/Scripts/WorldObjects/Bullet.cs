using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float bulletSpeed;

    Rigidbody2D myRigidBody;
	// Use this for initialization
	void Start () {
        myRigidBody = gameObject.GetComponent<Rigidbody2D>();
	}

    public void Init(Vector3 direction)
    {
        direction.Normalize();

        myRigidBody.velocity = bulletSpeed * direction;
    }
}

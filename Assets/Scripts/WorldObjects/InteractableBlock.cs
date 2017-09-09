using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBlock : MonoBehaviour {

    public DataTypes.World currentWorld;

    private Rigidbody2D myRigidBody2d;
    private Transform carrier;

    private void Start()
    {
        myRigidBody2d = this.gameObject.GetComponent<Rigidbody2D>();
        carrier = null;
    }

    private void Update()
    {
        // Move an object with its carrier
        if (carrier != null)
        {
            this.transform.position = carrier.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();

        if (player != null)
        {
            Debug.Log("Thowing a enter event");
            EventManager.instance.enterInteractableEvt.Invoke(this.gameObject, player.playerNumber);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();

        if (player != null)
        {
            EventManager.instance.exitInteractableEvt.Invoke(this.gameObject, player.playerNumber);
        }
    }

    public void PickUp(Transform followTarget)
    {
        myRigidBody2d.isKinematic = true;
        carrier = followTarget;
    }

    public void Drop()
    {
        myRigidBody2d.isKinematic = false;
        carrier = null;
    }
}

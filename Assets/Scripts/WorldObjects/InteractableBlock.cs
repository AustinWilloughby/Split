using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBlock : MonoBehaviour {

    public DataTypes.World currentWorld;

    private bool isInteractable;
    private Rigidbody2D myRigidBody2d;
    private Transform carrier;

    private void Start()
    {
        myRigidBody2d = this.gameObject.GetComponent<Rigidbody2D>();
        carrier = null;
        isInteractable = true;
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

    public bool PickUp(Transform followTarget)
    {
        if (isInteractable)
        {
            isInteractable = false;
            myRigidBody2d.isKinematic = true;
            carrier = followTarget;
            return true;
        }

        return false;
    }

    public void Drop()
    {
        isInteractable = true;
        myRigidBody2d.isKinematic = false;
        carrier = null;
    }

    public bool Teleport(DataTypes.World newWorld, float newWorldY)
    {
        if (isInteractable)
        {
            currentWorld = newWorld;
            transform.position = new Vector3(transform.position.x, newWorldY, transform.position.z);
            WorldManager.instance.MoveToWorld(newWorld, transform);

            return true;
        }

        return false;
    }
}

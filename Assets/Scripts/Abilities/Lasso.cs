using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lasso : MonoBehaviour {

    public Transform carryLocation;

    private PlayerMovement myPlayerInfo;

    private List<GameObject> interactables = new List<GameObject> ();
    private InteractableBlock currentlyCarrying = null;
    private bool isCarrying;

    void Start()
    {
        myPlayerInfo = gameObject.GetComponent<PlayerMovement>();
        EventManager.instance.enterInteractableEvt.AddListener(PlayerNextToInteractable);
        EventManager.instance.exitInteractableEvt.AddListener(PlayerLeftInteractable);
        EventManager.instance.blockOutOfBounds.AddListener(ResetBlockOOB);
        EventManager.instance.playerOutOfBounds.AddListener(RespawnBlock);
    }

    private void Update()
    {
        // A on Xbox controller
        /*if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire1");

        }
        // B on Xbox controller
        if (Input.GetButtonDown("Fire2"))
        {
            Debug.Log("Fire2");

        }*/
        // X on XBox controller
        if (Input.GetButtonDown("Fire3"))
        {
            if (isCarrying)
            {
                DropObject();
            }
            else
            {
                PickupObject();
            }
        }
    }

    public void PlayerNextToInteractable(GameObject interactable, int playerNumber)
    {
        if (myPlayerInfo.playerNumber == playerNumber)
        {
            interactables.Add(interactable);
        }
    }
    public void PlayerLeftInteractable(GameObject interactable, int playerNumber)
    {
        if (myPlayerInfo.playerNumber == playerNumber)
        {
            interactables.Remove(interactable);
        }
    }

    private void ResetBlockOOB(GameObject blockOOB)
    {
        InteractableBlock block = blockOOB.GetComponent<InteractableBlock>();

        if (block != null)
        {
            if (block == currentlyCarrying)
            {
                isCarrying = false;
            }
        }
    }

    private void RespawnBlock(int _playerNumber)
    {
        if (isCarrying && _playerNumber == myPlayerInfo.playerNumber)
        {
            EventManager.instance.blockOutOfBounds.Invoke(currentlyCarrying.gameObject);
        }
    }

    private GameObject FindClosestInteractable()
    {
        GameObject closestInteractable = null;
        foreach (GameObject interactable in interactables)
        {
            if (closestInteractable == null)
            {
                closestInteractable = interactable;
            }
            else
            {
                if ((this.gameObject.transform.position - interactable.transform.position).magnitude < (this.gameObject.transform.position - closestInteractable.transform.position).magnitude)
                {
                    closestInteractable = interactable;
                }
            }
        }

        return closestInteractable;
    }

    private void PickupObject()
    {
        if (myPlayerInfo.active)
        {
            var closestInteractable = FindClosestInteractable();

            if (closestInteractable != null)
            {
                var interactable = closestInteractable.GetComponent<InteractableBlock>();
                if (interactable.PickUp(carryLocation))
                {
                    isCarrying = true;
                    currentlyCarrying = interactable;
                }
            }
        }
    }

    private void DropObject()
    {
        if (myPlayerInfo.active)
        {
            isCarrying = false;
            currentlyCarrying.Drop();
            currentlyCarrying = null;
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    private PlayerMovement myPlayerInfo;

    private List<GameObject> interactables = new List<GameObject>();
    private InteractableBlock currentlyTeleported = null;
    private bool hasTeleported;

    void Start()
    {
        myPlayerInfo = gameObject.GetComponent<PlayerMovement>();

        EventManager.instance.enterInteractableEvt.AddListener(PlayerNextToInteractable);
        EventManager.instance.exitInteractableEvt.AddListener(PlayerLeftInteractable);
        EventManager.instance.blockOutOfBounds.AddListener(ResetBlockOOB);
    }

    private void Update()
    {
        // X on XBox controller
        if (InputManager.instance.GetButtonDownForPlayer(myPlayerInfo.playerNumber, "Fire3"))
        {
            if (hasTeleported)
            {
                BringObjectBack();
            }
            else
            {
                TeleportAlternateWorld();
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
            if (block == currentlyTeleported)
            {
                hasTeleported = false;
                currentlyTeleported = null;
            }
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

    private void TeleportAlternateWorld()
    {
        if (myPlayerInfo.active)
        {
            var closestInteractable = FindClosestInteractable();

            if (closestInteractable != null)
            {
                var interactable = closestInteractable.GetComponent<InteractableBlock>();

                hasTeleported = TeleportObject(interactable);
                if (hasTeleported)
                    currentlyTeleported = interactable;
            }
        }
    }

    private void BringObjectBack()
    {
        if (myPlayerInfo.active)
        {
            hasTeleported = !TeleportObject(currentlyTeleported);
        }
    }

    private bool TeleportObject(InteractableBlock teleportObj)
    {
        if (teleportObj.currentWorld == DataTypes.World.WorldOne)
        {
            return teleportObj.Teleport(DataTypes.World.WorldTwo, DataTypes.worldTwoY);  
        }
        else
        {
            return teleportObj.Teleport(DataTypes.World.WorldOne, DataTypes.worldOneY);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {

    private PlayerMovement myPlayerInfo;

    private const float worldOneY = 5.81f;
    private const float worldTwoY = -93.7f;

    private List<GameObject> interactables = new List<GameObject>();
    private InteractableBlock currentlyTeleported = null;
    private bool hasTeleported;

    void Start()
    {
        myPlayerInfo = gameObject.GetComponent<PlayerMovement>();
        EventManager.instance.enterInteractableEvt.AddListener(PlayerNextToInteractable);
        EventManager.instance.exitInteractableEvt.AddListener(PlayerLeftInteractable);
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
            return teleportObj.Teleport(DataTypes.World.WorldTwo, worldTwoY);  
        }
        else
        {
            return teleportObj.Teleport(DataTypes.World.WorldOne, worldOneY);
        }
    }
}

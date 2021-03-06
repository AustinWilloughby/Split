﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public static EventManager instance;

    [HideInInspector]
    public PlayerEnterInteractable enterInteractableEvt;
    [HideInInspector]
    public PlayerExitInteractable exitInteractableEvt;
    [HideInInspector]
    public PlayerEnterEndOfLevel playerEnterEndOfLevel;
    [HideInInspector]
    public PlayerExitEndOfLevel playerExitEndOfLevel;
    [HideInInspector]
    public PlayerTouchingFloor playerEnterFloor;
    [HideInInspector]
    public PlayerChangedBarrier playerChangedBarrier;
    [HideInInspector]
    public PlayerTouchRespawn playerTouchRespawn;
    [HideInInspector]
    public PlayerOutOfBounds playerOutOfBounds;
    [HideInInspector]
    public BlockOutOfBounds blockOutOfBounds;

    // Use this for initialization
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        enterInteractableEvt = new PlayerEnterInteractable();
        exitInteractableEvt = new PlayerExitInteractable();
        playerEnterEndOfLevel = new PlayerEnterEndOfLevel();
        playerExitEndOfLevel = new PlayerExitEndOfLevel();
        playerEnterFloor = new PlayerTouchingFloor();
        playerChangedBarrier = new PlayerChangedBarrier();
        playerTouchRespawn = new PlayerTouchRespawn();
        playerOutOfBounds = new PlayerOutOfBounds();
        blockOutOfBounds = new BlockOutOfBounds();
    }
}

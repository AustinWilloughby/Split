﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public static EventManager instance;

    [HideInInspector]
    public PlayerEnterInteractable enterInteractableEvt;
    [HideInInspector]
    public PlayerExitInteractable exitInteractableEvt;

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
    }
}
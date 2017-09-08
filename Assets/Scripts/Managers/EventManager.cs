using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public static EventManager instance;

    [HideInInspector]
    public EnterInteractable enterInteractableEvt;
    public ExitInteractable exitInteractableEvt;

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

        enterInteractableEvt = new EnterInteractable();
        exitInteractableEvt = new ExitInteractable();
    }
}

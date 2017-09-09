using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class PlayerEnterInteractable : UnityEvent<GameObject, int> {

}

[System.Serializable]
public class PlayerExitInteractable : UnityEvent<GameObject, int>
{

}


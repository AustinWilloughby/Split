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

[System.Serializable]
public class PlayerEnterEndOfLevel : UnityEvent<int>
{

}

[System.Serializable]
public class PlayerExitEndOfLevel : UnityEvent<int>
{

}

[System.Serializable]
public class PlayerTouchingFloor : UnityEvent<int>
{

}

[System.Serializable]
public class PlayerTouchRespawn : UnityEvent<GameObject, int>
{

}

[System.Serializable]
public class PlayerChangedBarrier : UnityEvent<bool, int>
{

}

[System.Serializable]
public class PlayerOutOfBounds : UnityEvent<int>
{

}

[System.Serializable]
public class BlockOutOfBounds : UnityEvent<GameObject>
{

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour {

    public static WorldManager instance;

    [SerializeField]
    private Transform worldOneRoot;
    [SerializeField]
    private Transform worldTwoRoot;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void MoveToWorldOne(Transform go)
    {
        go.parent = worldOneRoot;
    }

    public void MoveToWorldTwo(Transform go)
    {
        go.parent = worldTwoRoot;
    }
}

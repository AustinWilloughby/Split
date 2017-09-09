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

    public void MoveToWorld(DataTypes.World world, Transform go)
    {
        if (world == DataTypes.World.WorldOne)
        {
            go.parent = worldOneRoot;
        }
        else
        {
            go.parent = worldTwoRoot;
        }
    }
}

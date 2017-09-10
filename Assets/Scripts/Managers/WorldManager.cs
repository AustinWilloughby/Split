using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour {

    public static WorldManager instance;

    [SerializeField]
    private Transform worldOneRoot;
    [SerializeField]
    private Transform worldTwoRoot;
    [SerializeField]
    private PlayerMovement myPlayerOneInfo;
    [SerializeField]
    private PlayerMovement myPlayerTwoInfo;

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

    public Vector3 GetPlayerLocation(DataTypes.World world)
    {
        if (world == DataTypes.World.WorldOne)
            return myPlayerOneInfo.transform.position;
        else
            return myPlayerTwoInfo.transform.position;
    }
}

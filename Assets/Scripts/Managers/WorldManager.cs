using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private Dictionary<int, bool> playerEndOfLevel = new Dictionary<int, bool>();

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

        EventManager.instance.playerEnterEndOfLevel.AddListener(AddPlayerToEndOfLevelLookup);
        EventManager.instance.playerExitEndOfLevel.AddListener(RemovePlayerFromEndOfLevelLookup);
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
        {
            Debug.Log("Looking at player: " + myPlayerOneInfo.playerNumber + " at position: " + myPlayerOneInfo.transform.position);
            return myPlayerOneInfo.transform.position;
        }
        else
        {
            Debug.Log("Looking at player: " + myPlayerTwoInfo.playerNumber + " at position: " + myPlayerTwoInfo.transform.position);
            return myPlayerTwoInfo.transform.position;
        }
    }

    private void AddPlayerToEndOfLevelLookup(int player)
    {
        if (!playerEndOfLevel.ContainsKey(player))
        {
            playerEndOfLevel.Add(player, true);
        }

        if (playerEndOfLevel.ContainsKey(1) && playerEndOfLevel.ContainsKey(2))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void RemovePlayerFromEndOfLevelLookup(int player)
    {
        if (playerEndOfLevel.ContainsKey(player))
        {
            playerEndOfLevel.Remove(player);
        }
    }
}

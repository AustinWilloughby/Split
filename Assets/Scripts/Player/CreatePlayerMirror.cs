using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayerMirror : MonoBehaviour {

    public GameObject playerMirrorInstance;
    public Color playerMirrorColor;

    private PlayerMovement myPlayerInfo;

    private void Start()
    {
        myPlayerInfo = gameObject.GetComponent<PlayerMovement>();
        playerMirrorInstance.gameObject.GetComponent<SpriteRenderer>().color = playerMirrorColor;
        playerMirrorInstance.transform.parent = myPlayerInfo.transform.parent;
    }

    // Update is called once per frame
    void Update () {
        MoveMirrorImage();
	}

    private void MoveMirrorImage ()
    {
        if (myPlayerInfo.currentWorld == DataTypes.World.WorldOne)
        {
            playerMirrorInstance.transform.position = new Vector3(myPlayerInfo.transform.position.x, myPlayerInfo.transform.position.y - DataTypes.worldDiffY, transform.position.z);
        }
        else
        {
            playerMirrorInstance.transform.position = new Vector3(myPlayerInfo.transform.position.x, myPlayerInfo.transform.position.y + DataTypes.worldDiffY, transform.position.z);
        }
    }
}

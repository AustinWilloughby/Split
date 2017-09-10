using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protect : MonoBehaviour {

    public GameObject barrier;
    public float barrierOffset;

    private PlayerMovement myPlayerInfo;

    private void Start()
    {
        myPlayerInfo = gameObject.GetComponent<PlayerMovement>();
        barrier.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire4") && myPlayerInfo.active && !barrier.activeSelf)
        {
            PlaceBarrier(0.0f);
        }
        else if (Input.GetButtonUp("Fire4") && myPlayerInfo.active && barrier.activeSelf)
        {
            ReleaseBarrier();
        }

        if (Input.GetButtonDown("Fire5") && myPlayerInfo.active && !barrier.activeSelf)
        {
            PlaceBarrier(DataTypes.worldDiffY);
        }
        else if (Input.GetButtonUp("Fire5") && myPlayerInfo.active && barrier.activeSelf)
        {
            ReleaseBarrier();
        }
    }

    private void PlaceBarrier (float yOffset)
    {
        float newYOffset = 0.0f;
        if (myPlayerInfo.currentWorld == DataTypes.World.WorldOne)
        {
            newYOffset = -yOffset;
        }
        else
        {
            newYOffset = yOffset;
        }
        barrier.transform.position = new Vector3(gameObject.transform.position.x + barrierOffset, gameObject.transform.position.y + newYOffset, barrier.transform.position.z);
        barrier.SetActive(true);
        EventManager.instance.playerChangedBarrier.Invoke(true, myPlayerInfo.playerNumber);
    }

    private void ReleaseBarrier ()
    {
        barrier.SetActive(false);
        EventManager.instance.playerChangedBarrier.Invoke(false, myPlayerInfo.playerNumber);
    }
}

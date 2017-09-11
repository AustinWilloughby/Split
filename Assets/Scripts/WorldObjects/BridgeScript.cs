using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeScript : MonoBehaviour
{
    Vector3 activePosition;
    Vector3 inactivePosition;

    public SlideDirection direction;
    public bool active;

    // Use this for initialization
    void Start()
    {
        activePosition = transform.position;
        inactivePosition = transform.position;
        if (direction == SlideDirection.Left)
        {
            inactivePosition.x -= GetComponent<BoxCollider2D>().bounds.extents.x * 1.9f;
        }
        else
        {
            inactivePosition.x += GetComponent<BoxCollider2D>().bounds.extents.x * 1.9f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            transform.position = activePosition;
        }
        else
        {
            transform.position = inactivePosition;
        }
    }

    public void SetActiveState(bool state)
    {
        active = state;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();

        if (player != null)
        {
            EventManager.instance.playerEnterFloor.Invoke(player.playerNumber);
        }
    }
}
public enum SlideDirection
{
    Left,
    Right
};

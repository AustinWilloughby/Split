using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public string controllerNumber;
    public float deadzone = .3f;
    public float runspeed;
    public int playerNumber;
    public DataTypes.World currentWorld;
    public Vector3 directionFacing;

    Vector3 posUpdate;
    public bool active;

    // Use this for initialization
    void Start()
    {
        directionFacing = Vector3.right;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            posUpdate = transform.position;
            if (Mathf.Abs(Input.GetAxis("Horizontal")) > deadzone)
            {
                var dirChange = Input.GetAxis("Horizontal") * runspeed;
                posUpdate.x += dirChange;

                if (dirChange < 0.0f)
                {
                    directionFacing = Vector3.left;
                }
                else
                {
                    directionFacing = Vector3.right;
                }
            }
            if (Mathf.Abs(Input.GetAxis("Vertical")) > deadzone)
            {
                posUpdate.y += Input.GetAxis("Vertical") * runspeed;
            }
            transform.position = posUpdate;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            active = !active;

        }
    }
}

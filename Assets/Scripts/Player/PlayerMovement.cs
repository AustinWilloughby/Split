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

    Vector3 posUpdate;
    public bool active;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            posUpdate = transform.position;
            if (Mathf.Abs(Input.GetAxis("Horizontal")) > deadzone)
            {
                posUpdate.x += Input.GetAxis("Horizontal") * runspeed;
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

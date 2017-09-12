using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public string controllerNumber;
    public float deadzone = .3f;
    public float runspeed;
    public float maxRunspeed;
    public float jumpspeed;
    public int playerNumber;
    public bool active;
    public DataTypes.World currentWorld;
    public Color damageColor;

    [HideInInspector]
    public Vector3 directionFacing;

    private Vector3 respawnLocation;
    private Rigidbody2D myRigidbody2D;
    private bool playerCanJump;
    private bool canMove;

    // Use this for initialization
    void Start()
    {
        myRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        directionFacing = Vector3.right;
        playerCanJump = true;
        canMove = true;

        EventManager.instance.playerEnterFloor.AddListener(PlayerCanJump);
        EventManager.instance.playerChangedBarrier.AddListener(PlayerCanMove);
        EventManager.instance.playerTouchRespawn.AddListener(ChangeRespawnLocation);
        EventManager.instance.playerOutOfBounds.AddListener(RespawnPlayer);

        // comment out for one controller dev.
        active = true;
    }

    // Update is called once per frame
    void Update()
    {

        if (active && canMove)
        {
            Vector2 velocityUpdate = new Vector2(0.0f, 0.0f);
            var dirChange = InputManager.instance.GetHorizontalForPlayer(playerNumber);
            if (Mathf.Abs(dirChange) > deadzone)
            {
                if (dirChange < 0.0f)
                {
                    directionFacing = Vector3.left;
                }
                else
                {
                    directionFacing = Vector3.right;
                }

                velocityUpdate.x = dirChange * runspeed;
            }
            if (InputManager.instance.GetButtonDownForPlayer(playerNumber, "Fire1") && playerCanJump)
            {
                velocityUpdate.y = jumpspeed;
                playerCanJump = false;
            }
            myRigidbody2D.velocity += velocityUpdate;

            if (myRigidbody2D.velocity.x > maxRunspeed || myRigidbody2D.velocity.x < -maxRunspeed)
            {
                myRigidbody2D.velocity = new Vector2(maxRunspeed * directionFacing.x, myRigidbody2D.velocity.y);
            }
        }

        // For development with just one controller:
        // 1) Uncomment this line.
        // 2) Make sure one of the players is initially set to active and the other to inactive.
        // 3) Make sure inputmanager is always reading input for P1.
        /*if (Input.GetButtonDown("Fire2"))
        {
            active = !active;

        }*/
    }

    void PlayerCanJump(int _playerNumber)
    {
        if (_playerNumber == playerNumber)
        {
            playerCanJump = true;
        }
    }

    void PlayerCanMove(bool barrierActive, int _playerNumber)
    {
        if (_playerNumber == playerNumber)
        {
            canMove = !barrierActive;
        }
    }

    void ChangeRespawnLocation(GameObject _respawnLocation, int _playerNumber)
    {
        if (_playerNumber == playerNumber)
        {
            respawnLocation = new Vector3(_respawnLocation.transform.position.x, _respawnLocation.transform.position.y + 5.0f, transform.position.z);
        }
    }

    void RespawnPlayer(int _playerNumber)
    {
        if (_playerNumber == playerNumber)
        {
            transform.position = respawnLocation;
        }
    }
}

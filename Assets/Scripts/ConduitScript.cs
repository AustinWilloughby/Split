using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConduitScript : MonoBehaviour
{
    public ConduitType type;
    public ConduitScript partner;
    public BridgeScript target;
    public GameObject player;
    public float tolerance;
    public bool active;

    private Color defaultColor;

    // Use this for initialization
    void Start()
    {
        defaultColor = GetComponent<SpriteRenderer>().color;
        if(type == ConduitType.Emitter)
        {
            active = true;
        }
        else
        {
            active = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (type == ConduitType.Reciever)
        {
            active = false;
            if (GetComponent<Renderer>().isVisible)
            {
                if (partner.GetComponent<Renderer>().isVisible)
                {
                    if (player.name == "Player1")
                    {
                        if (mapToPlayer.y > 0 && partner.mapToPlayer.y < 0)
                        {
                            if (Mathf.Sign(mapToPlayer.x) == Mathf.Sign(partner.mapToPlayer.x))
                            {
                                active = CloseEnough(mapToPlayer, partner.mapToPlayer);
                            }
                        }
                    }
                    else
                    {
                        if (mapToPlayer.y < 0 && partner.mapToPlayer.y > 0)
                        {
                            if (Mathf.Sign(mapToPlayer.x) == Mathf.Sign(partner.mapToPlayer.x))
                            {
                                active = CloseEnough(mapToPlayer, partner.mapToPlayer);
                            }
                        }
                    }
                }
            }

            if (active)
            {
                target.SetActiveState(true);
                GetComponent<SpriteRenderer>().color = partner.GetComponent<SpriteRenderer>().color;
            }
            else
            {
                GetComponent<SpriteRenderer>().color = defaultColor;
            }
        }
    }

    public Vector2 mapToPlayer
    {
        get { return (Vector2)player.transform.position - (Vector2)transform.position; }
    }

    private bool CloseEnough(Vector2 oneVector, Vector2 twoVector)
    {
        if (Mathf.Abs(Mathf.Abs(oneVector.x) - Mathf.Abs(twoVector.x)) < tolerance)
        {
            return true;
            //if(Mathf.Abs(Mathf.Abs(oneVector.y) - Mathf.Abs(twoVector.y)) < tolerance)
            //{
            //    return true;
            //}
        }
        return false;
    }
}
public enum ConduitType
{
    Emitter,
    Reciever
};
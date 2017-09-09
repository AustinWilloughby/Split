using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConduitScript : MonoBehaviour
{
    public ConduitType type;
    public BridgeScript target;
    public float tolerance;
    public bool active;

    private List<GameObject> objectsOnTopOf = new List<GameObject>();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (type == ConduitType.Emitter)
        {
            Debug.Log("Something entered the conduit");

            objectsOnTopOf.Add(collision.gameObject);

            target.SetActiveState(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (type == ConduitType.Emitter)
        {
            Debug.Log("Something left the conduit");

            objectsOnTopOf.Remove(collision.gameObject);

            if (objectsOnTopOf.Count == 0)
            {
                target.SetActiveState(false);
                GetComponent<SpriteRenderer>().color = defaultColor;
            }
        }
    }
}
public enum ConduitType
{
    Emitter,
    Reciever
};
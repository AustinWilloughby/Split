using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    public static InputManager instance;

	// Use this for initialization
	void Start () {
		if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
	}

    public float GetHorizontalForPlayer (int playerNumber)
    {
        return Input.GetAxis("P" + playerNumber +"_Horizontal");
    }

    public bool GetButtonDownForPlayer (int playerNumber, string button)
    {
        return Input.GetButtonDown("P" + playerNumber + "_" + button);
    }

    public bool GetButtonUpForPlayer(int playerNumber, string button)
    {
        return Input.GetButtonUp("P" + playerNumber + "_" + button);
    }
}

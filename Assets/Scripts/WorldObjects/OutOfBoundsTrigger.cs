﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsTrigger : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement player = collision.gameObject.GetComponent<PlayerMovement>();

        if (player != null)
        {
            EventManager.instance.playerOutOfBounds.Invoke(player.playerNumber);
            return;
        }

        InteractableBlock block = collision.gameObject.GetComponent<InteractableBlock>();

        if (block != null)
        {
            EventManager.instance.blockOutOfBounds.Invoke(collision.gameObject);
            return;
        }
    }
}

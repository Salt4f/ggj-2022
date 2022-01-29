using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Being samurai;
    public Being ninja;

    public Being activeForm;

    public PlayerMovement movement;

    private void Awake()
    {
        GameManager.instance.playerManager = this;
        movement = GetComponent<PlayerMovement>();
        activeForm = samurai;
    }
}

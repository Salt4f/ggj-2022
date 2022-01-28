using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Being samurai;
    public Being ninja;

    private void Awake()
    {
        GameManager.instance.playerManager = this;
    }
}

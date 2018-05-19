using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameLogic
{
    private static GameLogicComponent instance;

    public static GameLogicComponent Instance { get { return GetInstance(); } }

    private static GameLogicComponent GetInstance()
    {
        if(instance == null)
        {
            instance = GameObject.Find("Canvas_Game").GetComponent<GameLogicComponent>();
        }

        return instance;
    }
}

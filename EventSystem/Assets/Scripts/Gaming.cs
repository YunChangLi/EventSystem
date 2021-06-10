using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaming : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        YellowGameEventCenter.EventCenterInit();
        YellowGameEventCenter.AddEvent(YellowGameEventCenter.GameState.GameStart, GameStart);
        YellowGameEventCenter.DispatchEvent(YellowGameEventCenter.GameState.GameStart);
    }

    // Update is called once per frame
    public void GameStart() 
    {
        Debug.Log("GameStart");
    }
}

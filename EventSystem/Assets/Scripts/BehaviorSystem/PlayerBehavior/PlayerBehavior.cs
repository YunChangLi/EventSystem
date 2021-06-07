using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerBehavior : MonoBehaviour
{
    public GameObject enemy;
    public BattleObject PlayerBattleObject;
    public PlayerUI _PlayerUI;

    private void Start()
    {
        PlayerBattleObject = this.GetComponent<BattleObject>();
        _PlayerUI = GetComponent<PlayerUI>();
        if (_PlayerUI != null)
            _PlayerUI.Initialization(PlayerBattleObject);
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
            PlayerBattleObject.TriggerTheBattle(enemy) ;
    }
}

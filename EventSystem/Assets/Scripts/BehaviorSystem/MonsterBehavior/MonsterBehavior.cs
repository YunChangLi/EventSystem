using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehavior : MonoBehaviour
{
    public GameObject enemy;
    public BattleObject MonsterBattleObject;
    //public PlayerUI _PlayerUI;

    private void Start()
    {
        MonsterBattleObject = this.GetComponent<BattleObject>();
        //_PlayerUI = GetComponent<PlayerUI>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
            MonsterBattleObject.TriggerTheBattle(enemy);
    }
}

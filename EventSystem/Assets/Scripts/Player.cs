using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void Awake()
    {
        YellowGameEventCenter.EventCenterInit();
    }
    // Start is called before the first frame update
    void Start()
    {
       
        YellowGameEventCenter.AddEvent<Monster.MonsterData>("PlayerGetDamage", OnHurt);
        YellowGameEventCenter.AddEvent<Monster.MonsterData>("PlayerKillMonster", MonsterKilled);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            OnAttack();
        }
    }
    public void OnAttack() 
    {
        Debug.Log("Attack");
        YellowGameEventCenter.DispatchEvent<int>("MonsterGetDamage", 20);
    }
    public void OnHurt(Monster.MonsterData data)
    {
        var info = data;
        Debug.Log("Hurt" + info.damage);
    }
    public void MonsterKilled(Monster.MonsterData data) 
    {
        Debug.Log("get " + data.DropItem);
        Debug.Log("get " + data.Gold + " dollar");
    }
}

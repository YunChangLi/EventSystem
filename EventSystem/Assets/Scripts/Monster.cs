using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private Player player;
    // Start is called before the first frame update
    private bool isAlive;
    public class MonsterData : IEventData 
    {
        public int damage ;
        public int blood;
        public string DropItem;
        public int Gold;

        public MonsterData(int damage , string dropItem , int Gold , int blood) 
        {
            this.damage = damage;
            this.DropItem = dropItem;
            this.Gold = Gold;
            this.blood = blood;
        }
        
    }
    MonsterData monsterData;
    void Start()
    {
        isAlive = true;
        monsterData = new MonsterData(10 , "爪子" , 100 , 10);
        YellowGameEventCenter.AddEvent<int>("MonsterGetDamage", GetDamage);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Z))
            YellowGameEventCenter.DispatchEvent<IEventData>("PlayerGetDamage", monsterData);
        if(monsterData.blood<=0 && isAlive)
        {
            YellowGameEventCenter.DispatchEvent<IEventData>("PlayerKillMonster", monsterData);
            OnDead();
            isAlive = false;
        }
            

    }
    public void GetDamage(int minusBlood) 
    {
        monsterData.blood -= minusBlood;
    }
    public void OnDead() 
    {
        Debug.Log("Monster Dead");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BattleObject : MonoBehaviour
{
    public string Name;
    public int damageValue;
    public bool isAlive { get; set; }
    public class DamageCompnent 
    {
        public bool IsCollidered;
        /// <summary>
        /// 死亡事件
        /// </summary>
        public event Action<BattleObject> OnDied;
        /// <summary>
        /// 受傷事件
        /// </summary>
        public event Action<BattleObject, BattleObject, int> OnHurt;
        /// <summary>
        /// 攻擊成功後的事件
        /// </summary>
        public event Action<BattleObject> OnAttacked;
        /// <summary>
        /// 擊殺成功
        /// </summary>
        public event Action<BattleObject, BattleObject> OnkillOther;
        public DamageCompnent() 
        {
            IsCollidered = true;
            OnHurt += OnChangedHP;
            OnDied += AttackerDied;
        }
        public void InBattle(BattleObject attacker, BattleObject enemy) 
        {
            var attackerDamageComponent = attacker._damageCompnent;
            var ohterDamageComponent = enemy._damageCompnent;

            if (IsCollidered) //after attacker attacked
            {
                if (attackerDamageComponent.OnAttacked != null) attackerDamageComponent.OnAttacked(attacker);
                if (ohterDamageComponent.OnHurt != null) ohterDamageComponent.OnHurt(attacker , enemy , attacker.damageValue);
            }
            if (!enemy.isAlive) 
            {
                if(attackerDamageComponent.OnkillOther != null) attackerDamageComponent.OnkillOther(attacker , enemy);
                if (ohterDamageComponent.OnDied != null) ohterDamageComponent.OnDied(enemy);
            }
        }
        public void OnChangedHP(BattleObject attacker , BattleObject enemy , int damage) 
        {
            Debug.Log(attacker.Name + " attack the " + enemy.Name + " " + damage + " damage ");
        }
        public void AttackerDied(BattleObject attacker)
        {
            Debug.Log(attacker.Name + " is dead ");
        }

    }
    public DamageCompnent _damageCompnent;

    public event Action<BattleObject, BattleObject> OnTriggerBattle;
    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        _damageCompnent = new DamageCompnent();
        OnTriggerBattle += _damageCompnent.InBattle;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TriggerTheBattle(GameObject Obj) 
    {
        var BatObj = Obj.GetComponent<BattleObject>();
        if (BatObj == null) return;
        if (OnTriggerBattle != null) 
        {
            OnTriggerBattle(this , BatObj);
        }
    }

}

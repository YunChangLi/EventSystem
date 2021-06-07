using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public class BattleUI
    {
        int HP_UI;
        int MP_UI;
        public BattleUI(BattleObject obj) 
        {
            var d_component = obj._damageCompnent;
            if (d_component != null) 
            {
                d_component.OnHurt += OnChangedHP;
            }
        }
        public void OnChangedHP(BattleObject Aobj, BattleObject enemy , int damage)
        {
            Debug.Log("UI show " + enemy.Name + " minus " + damage + " blood from " + Aobj.Name);
        }
    }

    public BattleUI battleUI { get; set; }
    // Start is called before the first frame update
    public void Initialization(BattleObject obj) 
    {
        battleUI = new BattleUI( obj);
    }
    

}
    

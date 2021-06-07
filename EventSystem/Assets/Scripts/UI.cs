using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        YellowGameEventCenter.AddEvent<Monster.MonsterData>("PlayerGetDamage", ChangeBlood);
        YellowGameEventCenter.AddEvent<int>("MonsterGetDamage", ChangeMonsterBlood);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeBlood(Monster.MonsterData data) 
    {
        Debug.Log("ChangeBlood" + data.damage );
    }
    public void ChangeMonsterBlood(int minusBlood) 
    {
        Debug.Log("MonsterChangeBlood" + minusBlood);
    }
}

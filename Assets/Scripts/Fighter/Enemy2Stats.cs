using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Stats : EnemyStats
{
    public Enemy2Stats()
    {
        MaxHp = 30;
        AttackDamage = new Stat();
        AttackDamage.Value = 5;
        AttackInterval = new Stat();
        AttackInterval.Value = 2;
        Label = "Enemy 2";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : FighterStats
{
    public EnemyStats()
    {
        MaxHp = 40;
        AttackDamage = new Stat();
        AttackDamage.Value = 10;
        AttackInterval = new Stat();
        AttackInterval.Value = 3;
        Label = "Enemy 1";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStats : FighterStats
{
    public HeroStats()
    {
        MaxHp = 100;
        AttackDamage = new Stat();
        AttackDamage.Value = 20;
        AttackInterval = new Stat();
        AttackInterval.Value = 3;
        Label = "Hero";
    }
}

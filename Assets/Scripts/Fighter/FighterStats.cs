using System;
using UnityEngine;

public class FighterStats : MonoBehaviour
{
    public string Label;
    public double MaxHp = 100;
    public double Hp;
    public Stat AttackDamage;
    public Stat AttackInterval;
    private void Awake()
    {
        Hp = MaxHp;
    }
    private void TakeDamage(int attackDamage)
    {
        Hp -= attackDamage;

        if (Hp <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        Debug.Log("DIE :"+Label);
    }
}

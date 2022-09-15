using System;
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class FighterStats : MonoBehaviour
{
    public string Label;
    public double MaxHp = 100;
    public double Hp = 100;
    public Stat AttackDamage;
    public Stat AttackInterval;

    private TextMeshPro statText;

    private void Start()
    {
        statText = transform.Find("StatText").GetComponent<TextMeshPro>();
        Hp = MaxHp;
        StartCoroutine(Attack());
    }
    private void OnEnable()
    {

    }
    public void UpdateGen()
    {
        statText.text = $"{Label}\nAttack damage: {AttackDamage.Value}\nAttack Interval: {AttackInterval.Value} sec\nHP: {Hp}/{MaxHp}";
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds((float)AttackInterval.Value);
        if (isActiveAndEnabled)
        {
            GameObject oToAttack = getClosetsFighter();
            if (oToAttack == null)
            {
                yield return StartCoroutine((nextGame()));
            }
            else
            {
                FighterStats toAttack = oToAttack.GetComponent<FighterStats>();
                //Debug.Log($"{Label} ATTACK {toAttack.Label}");
                if (toAttack.Hp > 0)
                {
                    toAttack.Hp -= AttackDamage.Value;
                    if (toAttack.Hp <= 0) AttackDamage.Value += 5;
                }
            }
            yield return StartCoroutine(Attack());
        }
    }

    IEnumerator nextGame()
    {
        yield return new WaitForSeconds(0.5f);
        GameSystem gs = GameObject.Find("GameSystem").GetComponent<GameSystem>();
        if (transform.tag == "Hero")
        {
            gs.showResult("WON");
        }
        else
        {
            gs.showResult("LOST");
        }
        gs.NextGame();
    }


    private GameObject getClosetsFighter()
    {
        float oldDistance = Mathf.Infinity;
        GameObject team = null;
        team = GameObject.Find(transform.tag == "Hero" ? "Enemies" : "Heroes");
        List<GameObject> fightersTeam = new List<GameObject>();
        int children = team.transform.childCount;
        for (int i = 0; i < children; ++i)
        {
            GameObject item = team.transform.GetChild(i).gameObject;
            if (item.activeSelf)
            {
                Debug.Log($"{transform.tag} {item.name}");
                fightersTeam.Add(item);
            }
        }
        GameObject closetsFighter = null;
        foreach (GameObject item in fightersTeam)
        {
            float dist = Vector3.Distance(this.gameObject.transform.position, item.transform.position);
            if (dist < oldDistance)
            {
                closetsFighter = item;
                oldDistance = dist;
            }
        }
        return closetsFighter;
    }
}

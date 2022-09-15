using System;
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class FighterStats : MonoBehaviour
{
    public string Label;
    public double MaxHp = 100;
    public double Hp;
    public Stat AttackDamage;
    public Stat AttackInterval;

    private TextMeshPro statText;

    private void Awake()
    {
        statText = transform.Find("StatText").GetComponent<TextMeshPro>();
        Hp = MaxHp;
        StartCoroutine(Attack());
    }
    private void Die()
    {
        Debug.Log("DIE :" + Label);
    }
    public void Update()
    {
        statText.text = $"{Label}\nAttack damage: {AttackDamage.Value}\nAttack Interval: {AttackInterval.Value} sec\nHP: {Hp}/{MaxHp}";
        if (Hp <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator Attack()
    {
        if (isActiveAndEnabled)
        {
            GameObject oToAttack = getClosetsFighter();
            if (oToAttack == null)
            {
                Debug.Log("DONE !");
            }
            else
            {
                FighterStats toAttack = oToAttack.GetComponent<FighterStats>();
                Debug.Log($"{Label} ATTACK {toAttack.Label}");
                toAttack.Hp -= AttackDamage.Value;
            }
            yield return new WaitForSeconds((float)AttackInterval.Value);
            StartCoroutine(Attack());
        }
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
            if (item.activeSelf) fightersTeam.Add(item);
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

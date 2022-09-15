using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    Vector3 localScale;
    FighterStats fighterStats;
    // Start is called before the first frame update
    void Start()
    {
        fighterStats = transform.parent.GetComponent<FighterStats>();
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        localScale.x = (float)(fighterStats.Hp / fighterStats.MaxHp);
        transform.localScale = localScale;
    }
}

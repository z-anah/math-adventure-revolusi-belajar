using UnityEngine;

[System.Serializable]
public class Stat 
{
    [SerializeField]
    private double value;

    public double Value { get => value; set => this.value = value; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats")]
public class Stats : ScriptableObject
{
    public int MaxHealth;
    public int MaxArmor;
    public float MovementSpeed;
    public float AttackSpeed;
    public int Attack;
}

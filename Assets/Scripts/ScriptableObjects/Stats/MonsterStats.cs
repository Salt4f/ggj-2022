using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "MonsterStats")]
public class MonsterStats : ScriptableObject
{
    public float FieldOfView;
    public float DistanceOfView;
    public float DistanceOfAttack;
    public float MinWanderDistance;
    public float MaxWanderDistance;
}

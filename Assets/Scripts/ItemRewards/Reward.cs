using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum RewardType
{
    health, 
    ammo, 
    weapon,
    item
}
[CreateAssetMenu(fileName = "Reward", menuName = "ScriptableObjects/RewardScriptableObject", order = 2)]
public class Reward : ScriptableObject
{
    [SerializeField]
    RewardType reward = RewardType.health;
    [SerializeField]
    int amount = 1;
}

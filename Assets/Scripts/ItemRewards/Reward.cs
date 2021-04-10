using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RewardType: int
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
    public RewardType reward = RewardType.health;
    [SerializeField]
    public int amount = 1;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RewardList", menuName = "ScriptableObjects/RewardListScriptableObject", order = 3)]
public class RewardList : ScriptableObject
{
    [SerializeField]
    List<Reward> rewardList;

    public Reward getReward(int i )
    {
        if (i > rewardList.Count)
            return null;
        return rewardList[i];
    }

    public int Count()
    {
        return rewardList.Count;
    }
}

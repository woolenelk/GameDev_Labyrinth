using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    private static RewardManager _instance;
    [SerializeField]
    public bool Claimed, Spawned;
    [SerializeField]
    public Reward CurrentRoomReward;
    public static RewardManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<RewardManager>();
            }

            return _instance;
        }
    }

    void Awake()
    {
        if (Instance != this)
        { Destroy(gameObject); }
        DontDestroyOnLoad(gameObject);
    }
}

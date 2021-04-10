using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class RewardManager : MonoBehaviour
    {
        public int room;
        private static RewardManager _instance;
        [SerializeField]
        public Reward CurrentRoomReward;
        [SerializeField]
        GameObject[] rewards;
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

        public void SpawnReward(Vector3 position)
        {
            GameObject temp = Instantiate(rewards[(int)CurrentRoomReward.reward], position, Quaternion.identity);
            temp.GetComponent<Item>().setAmount(CurrentRoomReward.amount);
        }
    }
}
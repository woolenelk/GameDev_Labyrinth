using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
namespace Character
{
    public class OpenDoorBehaviour : MonoBehaviour
    {
        [SerializeField]
        bool playerEnable = false;
        [SerializeField]
        string Level = "PlayScene";
        [SerializeField]
        Reward reward;
        [SerializeField]
        RewardList list;
        [SerializeField]
        Renderer rewardDisplay;

        [SerializeField]
        Material[] rewards;
        private void Awake()
        {
            reward = list.getReward(Random.Range(0, list.Count()));

            switch (reward.reward)
            {
                case RewardType.ammo:
                    rewardDisplay.material = rewards[0];
                    break;
                case RewardType.health:
                    rewardDisplay.material = rewards[1];
                    break;
                default:
                    break;
            }

        }
        public void Use()
        {
            Debug.Log("Door Used");
            if (playerEnable && GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
            {

                GameObject.FindGameObjectWithTag("RewardManager").GetComponent<RewardManager>().CurrentRoomReward = reward;
                GameObject.FindGameObjectWithTag("RewardManager").GetComponent<RewardManager>().room += 1;
                SceneManager.LoadScene(Level);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
                playerEnable = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
                playerEnable = false;
        }

    }
}
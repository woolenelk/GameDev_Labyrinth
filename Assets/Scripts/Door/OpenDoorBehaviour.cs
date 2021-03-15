using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
    private void Awake()
    {
        reward = list.getReward(Random.Range(0, list.Count()));
    }
    public void Use()
    {
        Debug.Log("Door Used");
        if (playerEnable)
        {
            GameObject.FindGameObjectWithTag("RewardManager").GetComponent<RewardManager>().CurrentRoomReward = reward;
            GameObject.FindGameObjectWithTag("RewardManager").GetComponent<RewardManager>().Spawned = false;
            GameObject.FindGameObjectWithTag("RewardManager").GetComponent<RewardManager>().Claimed = false;
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

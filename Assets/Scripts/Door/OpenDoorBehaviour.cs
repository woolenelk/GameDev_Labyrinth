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


    public void Use()
    {
        Debug.Log("Door Used");
        if (playerEnable)
            SceneManager.LoadScene(Level);
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

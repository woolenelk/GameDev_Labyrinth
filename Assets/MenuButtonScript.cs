using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonScript : MonoBehaviour
{
    [SerializeField]
    string level;
    
    public void OnMenuButtonPressed()
    {
        SceneManager.LoadScene(level);
    }
}

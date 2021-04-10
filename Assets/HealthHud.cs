using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HealthHud : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;
    Player player;
    private void Awake()
    {
        player = gameObject.GetComponent<Player>();
    }
    private void FixedUpdate()
    {
        text.text = ((int)(player.GetHealth())).ToString();
    }
}

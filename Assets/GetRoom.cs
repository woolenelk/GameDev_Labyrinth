using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace Character
{
    public class GetRoom : MonoBehaviour
    {
        RewardManager rewardManager;
        [SerializeField]
        Text RoomText;
        // Start is called before the first frame update
        void Start()
        {
            if (!GameManager.Instance.CursorActive)
                AppEvents.Invoke_MouseCursorEnable(true);
            RoomText.text = "Room: " + RewardManager.Instance?.room.ToString();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
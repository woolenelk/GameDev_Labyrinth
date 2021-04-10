using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Character
{
    public class MenuCleanUp : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            if (GameObject.FindGameObjectWithTag("RewardManager") != null)
                GameObject.FindGameObjectWithTag("RewardManager").GetComponent<RewardManager>().room = 0;
            GameObject temp = GameObject.FindGameObjectWithTag("Hud");
            Destroy(temp);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
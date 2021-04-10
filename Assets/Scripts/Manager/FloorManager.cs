using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Character
{
    public class FloorManager : MonoBehaviour
    {
        [SerializeField]
        GameObject Enemy;
        [SerializeField]
        FloorPatterns[] FloorPlan;
        [SerializeField]
        List<FloorInfo> blocks;
        [SerializeField]
        GameObject player;
        [SerializeField]
        int planNum = 0;
        [SerializeField]
        public List<Transform> SpawnPointsAvail = new List<Transform>();

        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            planNum = Random.Range(0, FloorPlan.Length - 1);
        }
        // Start is called before the first frame update
        void Start()
        {
            for (int block = 0; block < blocks.Count; block++)
            {
                if (FloorPlan[planNum].inUse[block])
                {
                    SpawnPointsAvail.Add(blocks[block].spawn);
                }
                blocks[block].SetInUse(FloorPlan[planNum].inUse[block]);

            }
            bool rewardspawned = false;
            int playerSpawn = Random.Range(0, SpawnPointsAvail.Count);
            for (int i = 0; i < SpawnPointsAvail.Count; i++)
            {
                if (i == playerSpawn)
                    player.transform.position = SpawnPointsAvail[playerSpawn].position;
                //otherwise Spawn enemy at other spawn points;
                else
                {
                    Instantiate(Enemy, SpawnPointsAvail[i]);
                    if (!rewardspawned)
                    {
                        rewardspawned = true;
                        GameObject.FindGameObjectWithTag("RewardManager").GetComponent<RewardManager>().SpawnReward(SpawnPointsAvail[i].position);
                    }
                }

            }
        }

        // Update is called once per frame
        void Update()
        {
            if (player == null)
            {
                SceneManager.LoadScene("GameOver");
            }
            
        }
    }
}
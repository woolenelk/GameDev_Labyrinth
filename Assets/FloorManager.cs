using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    [SerializeField]
    FloorPatterns[] FloorPlan;
    [SerializeField]
    List<FloorInfo> blocks;
    [SerializeField]
    GameObject player;
    [SerializeField]
    int planNum = 0;

    private void Awake()
    {
        planNum = Random.Range(0, FloorPlan.Length-1);
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int block = 0; block < blocks.Count; block++)
        {
            if (FloorPlan[planNum].inUse[block])
            {
                player.transform.position = blocks[block].spawn.position;
            }
            blocks[block].SetInUse(FloorPlan[planNum].inUse[block]);
            
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

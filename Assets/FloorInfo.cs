using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorInfo : MonoBehaviour
{
    [SerializeField]
    bool inUse = true;
    [SerializeField]
    GameObject WallOff;
    public Transform spawn => spawnPoint;
    [SerializeField]
    Transform spawnPoint;
    // Start is called before the first frame update

    

    private void Update()
    {
        WallOff.SetActive(!inUse);
    }

    public void ToggleInUse()
    {
        inUse = !inUse;
    }

    public void SetInUse(bool _inUse)
    {
        inUse = _inUse;
    }
}

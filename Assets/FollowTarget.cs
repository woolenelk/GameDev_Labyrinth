using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class FollowTarget : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera.Follow = GameObject.FindGameObjectWithTag("Follow").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

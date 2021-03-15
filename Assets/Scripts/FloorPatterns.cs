using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pattern", menuName = "ScriptableObjects/PatternScriptableObject", order = 1)]
public class FloorPatterns : ScriptableObject
{
    [SerializeField]
    public bool[] inUse = new bool [9];
}

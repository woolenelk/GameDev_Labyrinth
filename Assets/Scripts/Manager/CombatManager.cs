using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;

public class CombatManager : MonoBehaviour
{
    public static void Attack(Entity attacker, Entity defender, WeaponComponent weaponComponent)
    {
        if (attacker != defender)
            defender.Hit(weaponComponent.WeaponStats.Damage);
    }
}

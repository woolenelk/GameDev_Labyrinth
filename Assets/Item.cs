using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class Item : MonoBehaviour
    {
        [SerializeField]
        RewardType type;
        [SerializeField]
        int amount = 1;

        private void Start()
        {

        }

        public void setReward(RewardType _type)
        {
            type = _type;
        }

        public void setAmount(int _Amount)
        {
            amount = _Amount;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                switch (type)
                {
                    case RewardType.ammo:
                        other.gameObject.GetComponent<WeaponHolder>().AddBullets(amount);
                        break;
                    case RewardType.health:
                        other.gameObject.GetComponent<Player>().Heal(amount);
                        break;
                }
                Destroy(gameObject);
            }
        }
    }
}
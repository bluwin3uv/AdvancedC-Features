using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delegate
{
    public class LottyHealth : MonoBehaviour
    {
        public int health = 100;
        void Update()
        {
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
        
        public void TakeDamage(int damage)
        {
            health -= damage;
        }
    }
}

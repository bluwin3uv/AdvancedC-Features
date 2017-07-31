using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delegate
{
    public class Atttack : MonoBehaviour
    {
        public int damage = 10;
     
        protected virtual void OnTriggerEnter(Collider col)
        {
            LottyHealth health = col.GetComponent<LottyHealth>();
            if(health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }
}

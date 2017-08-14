using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abstract
{
    public abstract class Weapons : MonoBehaviour
    {
        public int damage = 10;
        public int ammo = 0;
        public int maxAmmo = 30;
        public float fireIntaval = 0.2f;
        public abstract void Fire();

        public virtual void Reaload()
        {
            ammo = maxAmmo;
        }

        
    }
}

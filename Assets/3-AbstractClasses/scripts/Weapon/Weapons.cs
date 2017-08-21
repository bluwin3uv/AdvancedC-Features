using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abstract
{
    public abstract class Weapons : MonoBehaviour
    {
        public GameObject bullet;
        public GameObject murray;
        public int damage = 10;
        public int ammo = 0;
        public int maxAmmo = 30;
        public float recoil = 5f;
        public float fireIntaval = 0.2f;

        public abstract void Fire();

        public virtual void Reaload()
        {
            ammo = maxAmmo;
        }

        public Bullets spawnBullet(Vector3 pos ,Quaternion rot)
        {
            GameObject clone = Instantiate(bullet, pos, rot);
            Bullets b = clone.GetComponent<Bullets>();
            Instantiate(murray, pos, rot);
            ammo--;
            return b;
        }
    }
}

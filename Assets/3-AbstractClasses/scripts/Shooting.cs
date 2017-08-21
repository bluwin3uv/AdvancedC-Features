using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Abstract
{
    [RequireComponent(typeof(Rigidbody2D))]

    public class Shooting : MonoBehaviour
    {
        public int weaponIndex = 0;
        private Weapons[] attachWeapons;
        private Rigidbody2D rb2d;

        void Awake()
        {
            attachWeapons = GetComponentsInChildren<Weapons>();
            rb2d = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            SwitchWeapon(weaponIndex);
        }

        void Update()
        {
            CheckFire();
            if(Input.GetKeyDown(KeyCode.Q))
            {
                CycleWeapon(-1);
            }

            if(Input.GetKeyDown(KeyCode.E))
            {
                CycleWeapon(1);
            }
        }

        void CheckFire()
        {
            Weapons curWeapon = attachWeapons[weaponIndex];
            if(Input.GetKeyDown(KeyCode.Space))
            {
                curWeapon.Fire();
                rb2d.AddForce(-transform.right * curWeapon.recoil, ForceMode2D.Impulse);
            }

        }

        void CycleWeapon(int amount)
        {
            int desiredIndex = weaponIndex + amount;
            if(desiredIndex >= attachWeapons.Length)
            {
                desiredIndex = 0;
            }
            else if(desiredIndex < 0)
            {
                desiredIndex = attachWeapons.Length - 1;
            }
            weaponIndex = desiredIndex;
            SwitchWeapon(weaponIndex);               
        }


        Weapons SwitchWeapon(int weaponIndex)
        {
            if(weaponIndex < 0 || weaponIndex > attachWeapons.Length)
            {
                return null;
            }

            for(int i = 0; i < attachWeapons.Length; i++)
            {
                Weapons w = attachWeapons[i];
                if (i == weaponIndex)
                {
                    w.gameObject.SetActive(true);
                }
                else
                {
                    w.gameObject.SetActive(false);
                }
            }
            return attachWeapons[weaponIndex];
        }
    }
}

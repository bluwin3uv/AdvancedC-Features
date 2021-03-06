﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Abstract
{
    public class ShotGun : Weapons
    {
        public int shells = 5;
        public float shootAngel = 45f;
        public float shootRadius = 5f;
        public float speed;

        public Vector2 GetDir(float angelD)
        {
            float angelR = angelD * Mathf.Deg2Rad;
            Vector2 dir = new Vector2(Mathf.Cos(angelR), Mathf.Sin(angelR));
            return transform.rotation * dir;
        }

        public override void Fire()
        {
            for(int i = 0; i < shells; i++)
            {
                Bullets b = spawnBullet(transform.position,transform.rotation);
                float randomAngle = Random.Range(-shootAngel, shootAngel);
                Vector3 direction = GetDir(randomAngle);
                b.aliveDist = shootRadius;
                b.Fire(direction);
            }
        }

#if UNITY_EDITOR
        [CustomEditor(typeof(ShotGun))]
        public class ShotgunEditor : Editor
        {
            void OnSceneGUI()
            {
                ShotGun gun = (ShotGun)target;
                Transform tran = gun.transform;
                Vector2 pos = tran.position;
                float angel = gun.shootAngel;
                float radius = gun.shootRadius; 
                Vector2 leftDir = gun.GetDir(angel);
                Vector2 rightDir = gun.GetDir(-angel);
                Handles.color = Color.red;
                Handles.DrawLine(pos, pos + leftDir * radius);
                Handles.DrawLine(pos, pos + rightDir * radius);

                Handles.color = Color.cyan;
                Handles.DrawWireArc(pos, Vector3.forward,rightDir,angel * 2,radius);
            }
        }
#endif 

    }
}

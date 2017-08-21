using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abstract
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullets : MonoBehaviour
    {
        public float speed = 10;
        public float aliveDist = 5f;
        private Rigidbody2D rb2d;
        private Vector3 shotPos;

        void Awake()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }

        void Start()
        {
            shotPos = transform.position;
        }

        public void Fire(Vector3 dir, float? speed = null)
        {
            float curSpeed = this.speed;
            if(speed != null)
            {
                curSpeed = speed.Value;
            }
            rb2d.AddForce(dir * curSpeed, ForceMode2D.Impulse);
        }
    }
}

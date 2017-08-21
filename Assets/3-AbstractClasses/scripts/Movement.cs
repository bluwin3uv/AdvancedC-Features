using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Abstract
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : MonoBehaviour
    {
        public float accleration = 26;
        public float hyperSpeed = 150f;
        public float decleration = 0.1f;
        public float rotataionSpeed = 5f;
        private float v;
        private float h;


        private Rigidbody2D rb2d;

        void Start()
        {
            rb2d = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            Input.GetAxisRaw("Vertical");
        }

        void FixedUpdate()
        {
            Acclerate();
            Declerate();
            Rotate();
        }

        void Acclerate()
        {
            float v = Input.GetAxisRaw("Vertical");
            Vector2 force = transform.right * v;
            if(Input.GetKey(KeyCode.LeftShift))
            {
                force *= hyperSpeed;
            }
            else
            {
                force *= accleration;
            }
            rb2d.AddForce(force);
        }

        void Declerate()
        {
            rb2d.velocity += -rb2d.velocity * decleration;
        }

        void Rotate()
        {
            float h = Input.GetAxis("Horizontal");
            transform.rotation *= Quaternion.AngleAxis(rotataionSpeed * h, Vector3.back);
        }
    }
}

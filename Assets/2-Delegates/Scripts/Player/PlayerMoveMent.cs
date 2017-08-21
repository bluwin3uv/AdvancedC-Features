using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delegate
{
    public class PlayerMoveMent : MonoBehaviour
    {
        public float acceleation = 200f;

        private Rigidbody rb;
        void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            Accelerate();
        }

        void Accelerate()
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 inputDir = new Vector3(h, 0, v);
            rb.AddForce(inputDir * acceleation);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Delegate
{
    public class Orc : Enemy
    {
        public float attackRange = 2f;
        public float meleeSpeed = 20f;
        public float meleeDelay = 0.3f;
        public GameObject attackBox;

        private bool isAttacking = false;

        protected override void Update()
        {
            base.Update();
            if(!isAttacking && IsCloseToTarget(attackRange))
            {
                StartCoroutine(Attack());
            }
        }

        IEnumerator Attack()
        {
            isAttacking = true;
            attackBox.SetActive(true);
            behaviourIndex = Behaviour.IDEL;
            yield return new WaitForSeconds(meleeDelay);
            behaviourIndex = Behaviour.SEEK;
            attackBox.SetActive(false);
            isAttacking = false;
        }
    }
}

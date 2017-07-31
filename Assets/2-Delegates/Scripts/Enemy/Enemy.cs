using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Delegate
{
    public abstract class Enemy : MonoBehaviour
    {

        public enum Behaviour
        {
            IDEL = 0,
            SEEK = 1
        }

        delegate void BehaviourFunk();

        public Behaviour behaviourIndex = Behaviour.SEEK;
        public Transform target;
        private List<BehaviourFunk> behaviourFuncs = new List<BehaviourFunk>();
        private NavMeshAgent agent;

        void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            behaviourFuncs.Add(Idel);
            behaviourFuncs.Add(Seek);
        }

        void Idel()
        {
            agent.Stop();
        }

        void Seek()
        {
            agent.Resume();
            if(target != null)
            {
                agent.SetDestination(target.position);
            }
        }

        public void SetTarget(Transform target)
        {
            this.target = target;
        }

        public bool IsCloseToTarget(float dist)
        {
            if (target != null)
            {
                float distToTarget = Vector3.Distance(transform.position, target.position);
                if (distToTarget <= dist)
                {
                    return true;
                }
            }
            return false;
        }
        protected virtual void Update()
        {
            behaviourFuncs[(int)behaviourIndex]();
        }
    }
}

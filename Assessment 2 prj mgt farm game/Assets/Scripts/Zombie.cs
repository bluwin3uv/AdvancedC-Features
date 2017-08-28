using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Zombie : MonoBehaviour
{
    public enum Action
    {
        IDEL = 0,
        SEEK = 1,
    }

    delegate void ActionFuntion();
    [Range(0,10)]
    public float health;
    public Action actIndex = Action.SEEK;
    public Transform target;
    private List<ActionFuntion> actFuncs = new List<ActionFuntion>();
    private NavMeshAgent agent;
    public Color fullHealth;
    public Color lowHealth;
    [HideInInspector]
    [Range(0, 1)]
    public float colorlerp;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        actFuncs.Add(Idel);
        actFuncs.Add(Seek);
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
        if(target != null)
        {
            float distToTarget = Vector3.Distance(transform.position, target.position);
            if(distToTarget <= dist)
            {
                return true;
            }
        }
        return false;
    }
    protected virtual void Update()
    {
        actFuncs[(int)actIndex]();
    }
}

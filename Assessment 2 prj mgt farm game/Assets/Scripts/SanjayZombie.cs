using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SanjayZombie : Zombie
{
    private BoxCollider bc;
    public GameObject player;
    public float attackRange = 2f;
    public float speed = 20f;
    public float attackTime = 0.3f;
    public GameObject attackBox;
    private float animLength = 0.4f;
    private bool isAttacking = false;
    private bool isHit;
    private Animator dmgAnim;

    private void Start()
    {
        dmgAnim = GetComponent<Animator>();
        bc = GetComponent<BoxCollider>();
    }

    protected override void Update()
    {
        dmgAnim.SetBool("Hit", isHit);
        base.Update();
        if(!isAttacking && IsCloseToTarget(attackRange))
        {
            StartCoroutine(Attack());
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.transform.name == "AttackBox")
        {
            if (player.GetComponent<Player>().foundEnemy && player.GetComponent<Player>().isNear)
            {
                StartCoroutine(GotHit());
            }
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;
        attackBox.SetActive(true);
        actIndex = Action.IDEL;
        yield return new WaitForSeconds(attackTime);
        actIndex = Action.SEEK;
        attackBox.SetActive(false);
        isAttacking = false;
    }

    IEnumerator GotHit()
    {
        isHit = true;
        yield return new WaitForSeconds(animLength);
        isHit = false;
    }
}

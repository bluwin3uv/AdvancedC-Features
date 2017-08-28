using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JulzZombie : Zombie
{
    private BoxCollider bc;
    public GameObject player;
    public float attackRange = 2f;
    public float speed = 10f;
    public float attackTime = 0.3f;
    public GameObject attackBox;
    private float animLength = 0.4f;
    private bool isAttacking = false;
    public bool isHit;
    private Animator dmgAnim;
    public GameObject hpBar;
    public GameObject healthbarheath;
    private MeshRenderer barMat;

    private void Start()
    {
        dmgAnim = GetComponent<Animator>();
        bc = GetComponent<BoxCollider>();
        barMat = healthbarheath.GetComponent<MeshRenderer>();
    }

    protected override void Update()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        barMat.material.color = Color.Lerp(lowHealth, fullHealth, colorlerp);
        colorlerp = health / 10;
        dmgAnim.SetBool("Hit", isHit);
        base.Update();
        if (!isAttacking && IsCloseToTarget(attackRange))
        {
            StartCoroutine(Attack());
        }
        hpBar.transform.rotation = Quaternion.Euler(hpBar.transform.forward);
        healthbarheath.transform.localScale = new Vector3(health / 10f, healthbarheath.transform.localScale.y, healthbarheath.transform.localScale.z);
        healthbarheath.transform.localPosition = new Vector3(-5 - health / -2, healthbarheath.transform.localPosition.y, healthbarheath.transform.localPosition.z);
        if (health <= 0)
        {
            health = 0;
            Destroy(gameObject, 0.1f);
            Destroy(hpBar);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.name == "AttackBox")
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
        health -= 1;
        yield return new WaitForSeconds(animLength);
        isHit = false;
    }
}

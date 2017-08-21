using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GUIStyle ty;
    public Zombie zom;
    public Texture2D red;
    public Vector3 rayLoc;
    public float moveSpeed;
    public float jumpForce;
    [Range(0, 1)]
    public float rotationSmoothness;
    public float blockTime;
    public float attackTime;
    private CharacterController controler;
    private float gravity = 14f;
    private Vector3 move;
    private Vector3 rotDir;
    public GameObject sheild;
    public GameObject sword;
    public GameObject attackBox;
    private bool isBlocking = false;
    private bool isAttacking = false;
    public bool showEnemyHP;
    public bool isNear;
    public bool foundEnemy;
    [Header("GUI Management")]
    public Rect barBackground;
    public Rect hpBar;
    
	void Start ()
    {
        controler = GetComponent<CharacterController>();
	}
	
	void Update ()
    {
        Movement();
        Action();
        FindEnemy();
	}

    void FindEnemy()
    {
        RaycastHit hit;
        Debug.DrawRay(rayLoc + transform.position, transform.forward, Color.blue);
        if(Physics.Raycast(rayLoc+ transform.position,transform.forward,out hit))
        {
            print(hit.transform.name);
            if(hit.transform.tag == "Enemy")
            {
                print("an enemy");
                foundEnemy = true;
            }
            else
            {
                foundEnemy = false;
            }
        }
        if(foundEnemy && isNear)
        {
            showEnemyHP = true;
            //StartCoroutine(ShowEnemyStats());
        }
        else
        {
            //StopCoroutine(ShowEnemyStats());
            showEnemyHP = false;
        }
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.transform.name == "ShowHudRange")
        {
            isNear = true;
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.transform.name == "ShowHudRange")
        {
            isNear = false;
        }
    }

    void Movement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        move = new Vector3(h, 0, v);
        move *= moveSpeed;
        move.y -= gravity *20 * Time.deltaTime;
        controler.Move(move * Time.deltaTime);
        if (h > 0.1f || h < -0.1f || v > 0.1f || v < -0.1)
        {
            rotDir = new Vector3(h, 0, v);
            Quaternion rotation = Quaternion.LookRotation(rotDir);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSmoothness);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            move.y = jumpForce;
        }   
    }

    void Action()
    {
        if (!isAttacking && !isBlocking)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Fire1") && isBlocking == false)
            {
                StartCoroutine(Attack());
            }
            if (Input.GetMouseButtonDown(1) || Input.GetButtonDown("Fire3") || Input.GetButtonDown("Fire2") && isAttacking == false)
            {
                StartCoroutine(Block());
            }
        }
    }

    void OnGUI()
    {
        float scw = Screen.width / 16;
        float sch = Screen.height / 9;
        if(showEnemyHP)
        {
            GUI.Box(new Rect(scw * barBackground.x, sch * barBackground.y, scw * barBackground.width, sch * barBackground.height), "");
            GUI.Box(new Rect(scw * barBackground.x, sch * barBackground.y, zom.health * 30/ barBackground.width, sch * barBackground.height),"",ty);
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true;
        sword.SetActive(true);
        attackBox.SetActive(true);
        yield return new WaitForSeconds(attackTime);
        sword.SetActive(false);
        attackBox.SetActive(false);
        isAttacking = false;
    }

    IEnumerator Block()
    {
        isBlocking = true;
        sheild.SetActive(true);
        yield return new WaitForSeconds(blockTime);
        sheild.SetActive(false);
        isBlocking = false;
    }

    IEnumerator ShowEnemyStats()
    {
        showEnemyHP = true;
        yield return new WaitForSeconds(1.5f);
        showEnemyHP = false;
    }
}

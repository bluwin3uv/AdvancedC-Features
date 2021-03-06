﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GUIStyle ty;
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
    public CameraController cam;
  
    
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
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.transform.tag == "HitRange")
        {
            isNear = true;
        }
        #region Camera Logic Manager
        if (col.transform.name == cam.triggers[0].name)
        {
            cam.sec1to2 = false;
            cam.sec2to1 = true;
            cam.sec2to3 = false;
        }
        if(col.transform.name == cam.triggers[1].name)
        {
            cam.sec1to2 = true;
            cam.sec2to1 = false;
            cam.sec2to3 = false;       
        }
        if(col.transform.name == cam.triggers[2].name)
        {
            cam.sec1to2 = false;
            cam.sec2to1 = false;
            cam.sec2to3 = true;
        }
        #endregion
    }


    void OnTriggerExit(Collider col)
    {
        if(col.transform.tag == "HitRange")
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

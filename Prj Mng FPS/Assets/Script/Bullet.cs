using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;
	void Start ()
    {
		
	}
	
	void Update ()
    {
        gameObject.transform.Translate(Vector3.forward * bulletSpeed);
        Destroy(gameObject, 1);		
	}
}

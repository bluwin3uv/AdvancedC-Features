using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RotateToVelocity : MonoBehaviour {
    private Rigidbody2D rb2d;
	void Awake ()
    {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	void Update ()
    {
        Vector2 velo = rb2d.velocity;
        float angle = Mathf.Atan2(velo.y, velo.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}

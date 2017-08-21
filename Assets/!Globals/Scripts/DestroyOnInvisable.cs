using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class DestroyOnInvisable : MonoBehaviour
{
    private Renderer rend;

	void Awake ()
    {
        rend = GetComponent<Renderer>();
	}

	void Update ()
    {
		if(!rend.isVisible)
        {
            Destroy(gameObject);
        }
	}
}

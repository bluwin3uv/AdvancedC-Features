using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muz : MonoBehaviour
{
    public int frameDelay = 1;
    private int framecount;
	// Update is called once per frame
	void Update ()
    {
	    if (framecount > frameDelay)
        {
            Destroy(gameObject);
        }  
	}
    void LateUpdate()
    {
        framecount++;
    }
}

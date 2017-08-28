using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float lockPlayerTime = 1;
    public float smoothMovment;
    public GameObject[] triggers;
    public Player player;
    public Vector3 curCamPos;
    public Vector3 minCamPos;
    public Vector3 maxCamPos;
    [Range(0, 1)]
    public float swichSmoothness;
    private Vector2 velo;
    [Header("Check")]
    public bool sec1to2;
    public bool sec2to1;
    public bool sec2to3;

    void Update()
    {
        SwitchingSectors();
    }

    void SwitchingSectors()
    {
        if(sec1to2)
        {
            curCamPos = transform.position;
            maxCamPos = new Vector3(0, 35, -40);
            minCamPos = maxCamPos;
            transform.position = Vector3.Lerp(curCamPos, maxCamPos,swichSmoothness);
        }
        if(sec2to1)
        {
            curCamPos = transform.position;
            maxCamPos = new Vector3(0, 35, 0);
            minCamPos = maxCamPos;
            transform.position = Vector3.Lerp(curCamPos, maxCamPos, swichSmoothness);
        }
        if(sec2to3)
        {
            lockPlayerTime -= Time.deltaTime;
            curCamPos = transform.position;
            maxCamPos = new Vector3(40, 35, -40);
            minCamPos = maxCamPos;
            transform.position = Vector3.Lerp(curCamPos,maxCamPos, swichSmoothness);
            if(lockPlayerTime <= 0)
            {
                lockPlayerTime = 0;
                curCamPos.x = Mathf.Clamp(player.transform.position.x, 40, 80);
                transform.position = curCamPos;
            }
        }
        else
        {
            lockPlayerTime = smoothMovment;
        }
    }

}

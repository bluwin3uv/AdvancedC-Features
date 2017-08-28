using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawFrame : MonoBehaviour
{
    public Texture2D bc;
    public Rect left;
    public Rect right;
    public bool paused;

    void OnGUI()
    {
        float scw = Screen.width / 16;
        float sch = Screen.height / 9;

        GUI.DrawTexture(new Rect(scw * left.x,sch * left.y,scw * left.width,sch * left.height), bc);
        GUI.DrawTexture(new Rect(scw * right.x, sch * right.y, scw * right.width, sch * right.height), bc);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScrollScene : MonoBehaviour
{
    public Texture2D cursorNormal;

    public Texture2D cursorOnButton;

    void Start()
    {

    }

    void Update()
    {
        /*if(Input.GetKeyDown(KayCode.Alpha1))
        {
            Cursor.SetCursor(cursorNormal.cursorNormalPos, CursorMode.Auto);
        }
        if (Input.GetKeyDown(KayCode.Alpha2))
        {
            Cursor.SetCursor(cursorOnButton, cursorOnButtonPos, CursorMode.Auto);
        }*/

    }

    public void OnMouseEnter()
    {
        Cursor.SetCursor(cursorOnButton, Vector2.zero, CursorMode.Auto);
        print("IN");
    }

    public void OnMouseExit()
    {
        Cursor.SetCursor(cursorNormal, Vector2.zero, CursorMode.Auto);
        print("OUT");
    }
}

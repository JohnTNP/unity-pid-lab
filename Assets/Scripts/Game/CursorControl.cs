using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorControl : MonoBehaviour
{

    public Texture2D cursor, pointer;
    private void Awake()
    {
        CursorSet();
    }
    public void ChangePointer()
    {
        Cursor.SetCursor(pointer, new Vector2(pointer.width/2.5f, 0), CursorMode.Auto);
    }
    public void CursorSet()
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
    }
    void Start()
    {

    }

}

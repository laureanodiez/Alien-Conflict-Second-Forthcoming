using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorMenu : MonoBehaviour
{
    public Texture2D crosshairs;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(crosshairs, new Vector2(crosshairs.width / 2, crosshairs.height / 2), CursorMode.Auto);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
    public static void interactWithTile(Tile tile, string key = "t")
    {
        if (Input.GetKeyDown(key))
        {
            tile.swapTile("dirt");
            tile.updateRenderer();
        }
    }

    public static GameObject activeUI(GameObject activate, GameObject switchTo, string key)
    { //switch between ui//toggle off if already active
        if (Input.GetKeyDown(key))
        {
            if (activate != null)
            {
                activate.SetActive(false);
            }
            if (activate != switchTo)
            {
                activate = switchTo;
                activate.SetActive(true);
            }
            else
            {
                activate = null;
            }
        }
        return activate;
    }

    public static Vector3 playerMovementInputs()
    {
        Vector3 dir = new Vector3(0, 0, 0);
        if (Input.GetKey("w"))
        {
            dir.z += .1f;
        }
        if (Input.GetKey("a"))
        {
            dir.x -= .1f;
        }
        if (Input.GetKey("s"))
        {
            dir.z -= .1f;
        }
        if (Input.GetKey("d"))
        {
            dir.x += .1f;
        }
        return dir;
    }
}

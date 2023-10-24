using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
    public static int getKeyNumber()
    {
        int keyNumber = 10; // Initialize to 0

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            keyNumber = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            keyNumber = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            keyNumber = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            keyNumber = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            keyNumber = 4;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            keyNumber = 6;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            keyNumber = 7;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            keyNumber = 8;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            keyNumber = 9;
        }
        return keyNumber;
    }

    public static float navigateHotbar()
    {
        return Input.GetAxis("Mouse ScrollWheel");
    }

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

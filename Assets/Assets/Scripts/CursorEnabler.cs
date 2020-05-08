using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorEnabler : MonoBehaviour
{
    public KeyCode CursorUnlockKey = KeyCode.Escape;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(CursorUnlockKey))
        {
            if (!Cursor.visible)
            {
                // Show the cursor
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                // Hide the cursor
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}

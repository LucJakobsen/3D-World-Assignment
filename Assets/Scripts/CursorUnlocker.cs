using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorUnlocker : MonoBehaviour
{
    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}

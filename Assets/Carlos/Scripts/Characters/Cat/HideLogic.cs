using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideLogic : MonoBehaviour
{
    public bool hide;
    public bool debug;
    public void Hide()
    {
        hide = true;
    }
    public void StopHide()
    {
        hide = false;
    }
    void Update()
    {
        if (debug)
        {
            if (Input.GetKeyDown(KeyCode.T))
                hide = !hide;
        }
    }
}

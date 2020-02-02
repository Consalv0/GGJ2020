using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideLogic : MonoBehaviour
{

    private Animator animator;
    public bool canHide;
    public bool hide;
    public bool debug;

    void Start()
    {
        animator=GetComponent<Animator>();
    }
    public void Hide()
    {
        if(!canHide)
        return;
        animator.SetBool("Hide",true);
        hide = true;
    }
    public void StopHide()
    {
        animator.SetBool("Hide",false);
        hide = false;
    }
    void Update()
    {
        if (debug)
        {
            if (Input.GetKeyDown(KeyCode.T))
               Hide();
        }
    }
}

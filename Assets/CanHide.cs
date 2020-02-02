using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanHide : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag=="Player")
        {
            col.GetComponent<HideLogic>().canHide=true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.tag=="Player")
        {
            col.GetComponent<HideLogic>().canHide=false;
            col.GetComponent<HideLogic>().hide=false;
        }
    }
}

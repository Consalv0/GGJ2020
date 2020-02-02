using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerInfoContainer : MonoBehaviour
{
    public string animationTrigger;
    public int layerToGo;


    public bool CanModify(int currentLayer)
    {
        
        if(currentLayer!=layerToGo)
        {
           return true;
        }
        return false;
    }

}

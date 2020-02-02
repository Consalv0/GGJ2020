using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerManager : MonoBehaviour
{

    [SerializeField] GameObject referenceAnimator;
    [SerializeField] GameObject referenceLayerMask;
    void OnTriggerEnter2D(Collider2D col)
    {
        LayerInfoContainer lay=col.gameObject.GetComponent<LayerInfoContainer>();
        if(lay==null)
        return;

        if (lay.CanModify(referenceLayerMask.layer))
        {
            string trigger = col.gameObject.GetComponent<LayerInfoContainer>().animationTrigger;
            referenceAnimator.GetComponent<Animator>().SetTrigger(trigger);
            referenceLayerMask.layer = col.gameObject.GetComponent<LayerInfoContainer>().layerToGo;
        }

    }
}

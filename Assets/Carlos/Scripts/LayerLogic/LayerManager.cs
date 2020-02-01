using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerManager : MonoBehaviour
{
    [SerializeField] bool test;
    [SerializeField] int maxLayerValue;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (test)
            DebugLayerChanger();
    }

    private void DebugLayerChanger()
    {
        
        int currentlayer = transform.GetChild(0).gameObject.layer;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentlayer++;

            if (currentlayer > maxLayerValue)
                currentlayer -= 3;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentlayer--;

            if (currentlayer < maxLayerValue-2)
                currentlayer =maxLayerValue;
        }
      transform.GetChild(0).gameObject.layer=currentlayer;
    }
}

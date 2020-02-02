using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DebugCurrentLayer : MonoBehaviour
{
    [SerializeField]Text layerText;
    [SerializeField]bool debug;
    // Start is called before the first frame update
    
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(debug)
        {
            layerText.text=LayerMask.LayerToName(transform.GetChild(0).gameObject.layer);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMovement : MonoBehaviour
{

    [SerializeField] float speed;  
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
            transform.Translate(new Vector3(-speed,0,0)*Time.deltaTime,Space.World);
        
        if(Input.GetKey(KeyCode.D))
             transform.Translate(new Vector3(speed,0,0)*Time.deltaTime,Space.World);
        
        
    }
}

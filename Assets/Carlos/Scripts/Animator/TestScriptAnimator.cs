using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScriptAnimator : MonoBehaviour
{
   [SerializeField]Animator animTest;

   void Update()
   {
       if(Input.GetKeyDown(KeyCode.P))
       {
           animTest.SetTrigger("GoBack");
       }
       if(Input.GetKeyDown(KeyCode.F))
       {
           animTest.SetTrigger("GoFoward");
       }
   }

}

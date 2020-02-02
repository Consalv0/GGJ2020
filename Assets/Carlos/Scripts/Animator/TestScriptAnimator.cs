using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScriptAnimator : MonoBehaviour
{
   [SerializeField]Animator animTest;

   void Update()
   {
       if(animTest.GetCurrentAnimatorStateInfo(0).IsName("Back"))
       {
           
       }
   }

}

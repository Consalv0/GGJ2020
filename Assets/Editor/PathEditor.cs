using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(Path))]
public class PathEditor : Editor
{
   
    // Start is called before the first frame update
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Path path = (Path)target;

        if (path.parentWayPoint != null)
        {
           
            if (path.parentWayPoint.gameObject.transform.childCount > 0)
            {
                 
                if (path.wayPoints == null)               
                    CreateList(path);
                
                else if (path.wayPoints.Count == 0)                   
                     CreateList(path);

                  
            }
        }

        if(GUILayout.Button("Reloade Father"))
        {
            CreateList(path);
        }
    }

    private void CreateList(Path path)
    {
        path.wayPoints = new List<SpecialWayPoints>();
       

        for (int i = 0; i < path.parentWayPoint.gameObject.transform.childCount; i++)
        {
            SpecialWayPoints special = new SpecialWayPoints();
            special.points = path.parentWayPoint.gameObject.transform.GetChild(i).transform;
            path.wayPoints.Add(special);
        }

    }

    private void OnValidate()
    {
        Debug.Log("Cambie");
         Path path = (Path)target;
         CreateList(path);
    }
}

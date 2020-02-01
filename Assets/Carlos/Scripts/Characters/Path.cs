using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{

    public GameObject parentWayPoint;

    public List<Transform> wayPoints;
    [SerializeField]float speed;
    [SerializeField]float limitDistance;
    private int currentPoint;

    // Start is called before the first frame update
    void Start()
    {
        wayPoints= new List<Transform>();
        for(int i=0; i<parentWayPoint.transform.childCount;i++)
        {
            wayPoints.Add(parentWayPoint.transform.GetChild(i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if(currentPoint>wayPoints.Count-1)
        return;

        Vector3 vector= wayPoints[currentPoint].position-transform.position;
        transform.Translate(vector.normalized*speed*Time.deltaTime,Space.World);

        if(Vector3.Distance(transform.position,wayPoints[currentPoint].position)<limitDistance)
            currentPoint++;
        
    }
}

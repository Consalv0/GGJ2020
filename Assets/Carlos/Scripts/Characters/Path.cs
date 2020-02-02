using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{

    public GameObject parentWayPoint;

    public List<SpecialWayPoints> wayPoints;
    [SerializeField] float speed;
    [SerializeField] float limitDistance;
    private int currentPoint;
    private bool canStop;


    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (currentPoint > wayPoints.Count - 1)
        {
            currentPoint = 0;
            return;
        }
        canStop = wayPoints[currentPoint].stop;
        Vector3 vector = wayPoints[currentPoint].points.position - transform.position;

        transform.Translate(vector.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, wayPoints[currentPoint].points.position) < limitDistance)
        {
            if (canStop)
            {
                canStop = !wayPoints[currentPoint].CheckStopTime();
                
                if (canStop)
                    return;
            }
            currentPoint++;
        }


    }
}

[System.Serializable]
public class SpecialWayPoints
{
    public bool stop;

    public float time = 6;
    public Transform points;
    private float currentTime;

    public SpecialWayPoints()
    {
        currentTime = time;
    }
    public bool CheckStopTime()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0)
        {
            currentTime = time;
            return true;
        }

        return false;
    }
}

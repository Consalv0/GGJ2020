using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Catch : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    [SerializeField] float radius;
    [SerializeField] float minRadius;

    [SerializeField] Transform target;

    [SerializeField] float speed;
    Path pathScript;
    float dist;
    private Vector3? targetLastPosition = null;
    public UnityEvent loseEvent;
    bool search;

    HideLogic cat;

    bool catched = false;
    // Start is called before the first frame update

    void Start()
    {
        cat = target.GetComponent<HideLogic>();
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, minRadius);
    }

    void Update()
    {


        if (pathScript == null)
            pathScript = gameObject.GetComponent<Path>();

        dist = Vector3.Distance(target.localPosition, gameObject.transform.position);
        //        Debug.Log(dist);

        if (dist <= radius && !search && !cat.hide)
        {

            search = true;
            pathScript.detect = false;
        }
        if (search)
            SearchForLastPosition();

    }

    private void SearchForLastPosition()
    {
        if (cat.hide)
        {
            search = false;
            pathScript.detect = false;
            return;
        }

        pathScript.detect = true;
        //booleano del gato
        Debug.Log("Te veo");

        Vector3 direction = (Vector3)target.transform.position - transform.position;
        direction = new Vector3(direction.x, 0, direction.z);
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
        TryToCatch();

        if (direction.magnitude < 0.5)
        {
            search = false;
            pathScript.detect = false;
        }


    }
    private void TryToCatch()
    {
        if (cat.hide)
        {
            search = false;
            pathScript.detect = false;
            return;
        }
        if (dist <= minRadius && !catched)
        {
            catched = true;
            AudioSource.PlayClipAtPoint(clip, cat.transform.position);
            loseEvent.Invoke();
            Debug.Log("Te tengo");
        }
    }
}

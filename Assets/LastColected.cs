using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class LastColected : MonoBehaviour
{
   [SerializeField] AudioClip clip;
    [SerializeField] UnityEvent victory;
    [SerializeField] GameObject destroy;
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag!="Player")
        return;
        AudioSource.PlayClipAtPoint(clip,gameObject.transform.position);
        victory.Invoke();
        gameObject.SetActive(false);
    }
}

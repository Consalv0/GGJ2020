using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colected : MonoBehaviour
{
    [SerializeField] AudioClip clip;
    [SerializeField] GameObject next;
    [SerializeField] GameObject destroy;
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag!="Player")
        return;
        AudioSource.PlayClipAtPoint(clip,gameObject.transform.position);
        next.SetActive(true);
        Destroy(destroy);
    }
}

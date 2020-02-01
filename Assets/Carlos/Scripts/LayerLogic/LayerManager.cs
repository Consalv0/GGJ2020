using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class LayerManager : MonoBehaviour
{
    [SerializeField] bool test;
    [SerializeField] int maxLayerValue;
    [SerializeField] GameObject toChangeLayer;
    [SerializeField] float speed;
    private bool canChangePosition;
    private float Zvalue;
    private float ZvalueToGo;
    [SerializeField]UnityEvent animationEvent;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (test)
            DebugLayerChanger();

        if (canChangePosition)
        {
            MoveToPosition();
        }
    }

    private void DebugLayerChanger()
    {

        int currentlayer = transform.GetChild(0).gameObject.layer;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentlayer++;

            if (currentlayer > maxLayerValue)
                currentlayer -= 3;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            currentlayer--;

            if (currentlayer < maxLayerValue - 2)
                currentlayer = maxLayerValue;
        }
        transform.GetChild(0).gameObject.layer = currentlayer;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log(collider.name);
        LayerInfoContainer container = collider.GetComponent<LayerInfoContainer>();
        if (container != null)
        {
            toChangeLayer.gameObject.layer = container.layerToGo;
            canChangePosition = true;
            Zvalue = transform.position.z;
            ZvalueToGo = container.PointToGo.position.z;
            Vector3 currentPosition = new Vector3(0, 0, Zvalue);
            Vector3 positionToGo = new Vector3(0, 0, ZvalueToGo);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        canChangePosition = false;
    }
    public void MoveToPosition()
    {
        GameObject parent = transform.parent.gameObject;
        animationEvent.Invoke();
        //float horizontalAxis = Input.GetAxis("Horizontal");
//       parent.transform.parent.GetComponent<Animator>().SetBool("GoBack",true);

        //parent.transform.position = new Vector3(transform.position.x, transform.position.y, ZvalueToGo);
        // iTween.MoveBy(parent.gameObject,iTween.Hash("z",ZvalueToGo,"time"));

        // transform.position=new Vector3(transform.position.x,transform.position.y,Zvalue);
        // goTo = (new Vector3(0, 0, Zvalue)) - (new Vector3(0, 0, ZvalueToGo));

        // parent.transform.Translate(goTo * speed * Time.deltaTime);

    }
}

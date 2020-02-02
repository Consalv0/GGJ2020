using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField]DayData data;

    void Start()
    {
        data=new DayData();
    }
}

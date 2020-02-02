using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="DayData")]
public class DayData : ScriptableObject
{
    

    [SerializeField]
    public int badDays;

    [SerializeField]
    public int goodDays;

    public void AddBadDay()
    {
        badDays++;
    }

    public void AddGoodDay()
    {
        goodDays++;
    }
    public void Reset()
    {
        badDays=0;
        goodDays=0;
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayTimer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float timer;

    [SerializeField]
    private int days;

    [SerializeField]
    private int maxDays;

    [SerializeField]
    private float totalTime;

    [SerializeField]
    public int badDays;

    [SerializeField]
    public int goodDays;

    [SerializeField]
    private Text timeLeft;

    [SerializeField]
    private Text daysLeft;

    [SerializeField]
    public MusicManager music;

    [SerializeField] DayData data;

    public void Start()
    {
        badDays=data.badDays;
        goodDays=data.goodDays;
    }
    // Update is called once per frame
    void Update()
    {
        CountDown();
    }

    void DaysLeft()
    {
        daysLeft.text = "Dia: " + (days).ToString();
    }

    public void SkipDay(bool succes)
    {

        if (succes)
            goodDays++;
        else
        {
            badDays++;
        }

        if(days < maxDays)
        {
            //Reseteo de dia
            timer = totalTime;
            days++;
            
        }

        else if(days >= maxDays)
        {
            //Game Over
            if(goodDays > badDays)
            {
                //Good Ending
            }
            else
            {
                //Bad Ending
            }
        }

        music.playM = true;

    }

    public void CountDown()
    {

        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            if (days < maxDays)
            {
                //Reseteo de dia
                timer = totalTime;
                days++;
                badDays++;
            }

            else if (days >= maxDays)
            {
                //Game Over
            }

            music.playM = true;
        }

        string realTime = string.Format("{0}:{1:00}", (int)timer / 60, (int)timer % 60);
        timeLeft.text = realTime;

        DaysLeft();
    }
}

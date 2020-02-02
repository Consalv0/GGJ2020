using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip goodMusic1;

    [SerializeField]
    private AudioClip goodMusic2;

    [SerializeField]
    private AudioClip badMusic1;

    [SerializeField]
    private AudioClip badMusic2;

    [SerializeField]
    private AudioClip neutralMusic;

    [SerializeField]
    private AudioSource audio;

    [SerializeField]
    private DayTimer day;

    public bool playM;

    // Start is called before the first frame update
    void Start()
    {
        audio = gameObject.AddComponent<AudioSource>();
        playM = true;
        audio.loop = true;

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    audio.Stop();
        //    audio.clip = badMusic2;
        //    audio.Play();
        //    playM = false;
        //}
        PlayMusic();
    }

    void PlayMusic()
    {
        if (playM)
        {
            if (day.goodDays > day.badDays)
            {
                if (day.goodDays == 1)
                {
                    audio.Stop();
                    audio.clip = goodMusic1;
                    audio.Play();
                    
                }
                if (day.goodDays == 2)
                {
                    audio.Stop();
                    audio.clip = goodMusic2;
                    audio.Play();
                }
                playM = false;

            }
            else if (day.badDays > day.goodDays)
            {
                if (day.badDays == 1)
                {
                    audio.Stop();
                    audio.clip = badMusic1;
                    audio.Play();
                }
                if (day.badDays == 2)
                {
                    audio.Stop();
                    audio.clip = badMusic2;
                    audio.Play();
                }
                playM = false;
            }
            else
            {
                audio.Stop();
                audio.clip = neutralMusic;
                audio.Play();
                playM = false;
            }
        }
        //if (Input.GetKeyDown(KeyCode.N))
        //{
        //    audio.Stop();
        //    audio.clip = goodMusic1;
        //    audio.Play();
        //}
        //if (Input.GetKeyDown(KeyCode.O))
        //{
        //    audio.Stop();
        //    audio.clip = goodMusic2;
        //    audio.Play();
        //}
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    audio.Stop();
        //    audio.clip = badMusic1;
        //    audio.Play();
        //}



    }
}

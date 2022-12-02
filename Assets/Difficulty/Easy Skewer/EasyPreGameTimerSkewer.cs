using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EasyPreGameTimerSkewer : MonoBehaviour
{
    public float CountdownToStart;
    public float CountdownToStartRestart;
    public float milliseconds;
    public EasyGameModeSkewer easyGameModeSkewerScript;
    public GameObject[] disabledGameObjects;
    public EasyGameTimerSkewer easyGameTimerSkewerScript;
    public TMP_Text timerText;
    public AudioSource countdownSound;

    void Awake()
    {
        CountdownToStartRestart = CountdownToStart;
    }
    void OnEnable()
    {
        CountdownToStart = CountdownToStartRestart;
        milliseconds = 0;
        DisableObjectsOnStart();
        countdownSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        CountdownToStart -= Time.deltaTime;
        milliseconds = (CountdownToStart % 1) * 100;
        DisplayTimer();
        if(CountdownToStart <= 0 && milliseconds <=0)
        {
            
            easyGameModeSkewerScript.enabled = true;
            easyGameTimerSkewerScript.enabled = true;
            enabled = false;
        }
    }

    private void DisplayTimer()
    {
        timerText.text = string.Format ("{0:00}:{1:00}", CountdownToStart, milliseconds);
    }

    private void DisableObjectsOnStart()
    {
        for (int i = 0; i < disabledGameObjects.Length; i++)
        {
            disabledGameObjects[i].SetActive(false);
        }
    }
}